using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatasLeonardo
{
    public class PeriodoPassado
    {
        public DateTime DataDesejada { get; private set; }
        private int DiasPassados { get; set; }
        private List<String> lista = new List<string>();
        public string StringDataExtenso { get; private set; }

        private DateTime dataFixa = new DateTime(2021, 05, 26, 20, 59, 49);


        public PeriodoPassado(int numeroDias)
        {
            DiasPassados = numeroDias;

            PreencherListaTempos();

            DivirDiasDataEmTemposNaLista();

            PassarListaParaExtenso();

            CarregarStringData();
        }

        public PeriodoPassado(DateTime data)
        {
            //arrumando valores
            DataDesejada = data;
            DiasPassados = Convert.ToInt32(tempo());
            PreencherListaTempos();


            if (DiasPassados != 0)
            {
                DivirDiasDataEmTemposNaLista();

                PassarListaParaExtenso();

                CarregarStringData();
            }
            else
            {
                if (ColocarHorasMinutosSegundosNaLista())
                {
                    PassarListaHorasEmExtenso();

                    CarregarStringHoras();
                }
            }
        }

        private void CarregarStringHoras()
        {
            StringDataExtenso += lista[0];
            StringDataExtenso += lista[1];
            StringDataExtenso += lista[2];
        }

        private void PassarListaHorasEmExtenso()
        {
            for (int i = 0; i < 4; i++)
            { 
                    if (i == 0)
                    {
                        lista[i] = PegarTextoSemana(Convert.ToInt32(lista[i]));
                        lista[i] += DeveSerUmUma(i) ? " Horas, " : " Hora, ";
                    }                                            
                    else if (i == 1)
                    {
                        lista[i] = PegarTextoNormal(Convert.ToInt32(lista[i]));  
                        lista[i] += DeveSerUmUma(i) ? " Minutos e " : " Minuto e ";
                    }
                    else if (i == 2)
                    {
                        lista[i] = PegarTextoNormal(Convert.ToInt32(lista[i]));   
                        lista[i] += DeveSerUmUma(i) ? " Segundos" : " Segundo";
                    }            
            }
        }

        private bool ColocarHorasMinutosSegundosNaLista()
        {
            if (dataFixa < DataDesejada)
            {
                StringDataExtenso = "Data No futuro da data de comparação";
                return false;
            }
            else if (dataFixa == DataDesejada)
            {
                StringDataExtenso = "Datas Iguais";
                return false;
            }
            else
            {
                lista[0] = Convert.ToString(dataFixa.Hour  -DataDesejada.Hour);
                lista[1] = Convert.ToString(dataFixa.Minute  -DataDesejada.Minute);
                lista[2] = Convert.ToString(dataFixa.Second  -DataDesejada.Second);
                return true;
            }
        }


        private void CarregarStringData()       //pode Ser Refatorado ainda, assim como o da horas
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] != "Deletar" && lista[i] != "0")
                {
                    if (i == 0)
                    {
                        StringDataExtenso += lista[i];
                        StringDataExtenso += DeveSerUmUma(i) ? " Anos" : " Ano";
                    }
                    else if (i == 1)
                    {
                        if (StringDataExtenso != null)
                        {
                            StringDataExtenso += ", ";
                            StringDataExtenso += lista[i];
                            StringDataExtenso += DeveSerUmUma(i) ? " Meses" : " Mês";
                        }
                        else
                        {
                            StringDataExtenso += lista[i];
                            StringDataExtenso += DeveSerUmUma(i) ? " Meses" : " Mês";
                        }
                    }
                    else if (i == 2)
                    {
                        if (StringDataExtenso != null)
                        {
                            StringDataExtenso += ", ";
                            StringDataExtenso += lista[i];
                            StringDataExtenso += DeveSerUmUma(i) ? " Semanas" : " Semana";
                        }
                        else
                        {
                            StringDataExtenso += lista[i];
                            StringDataExtenso += DeveSerUmUma(i) ? " Semanas" : " Semana";
                        }
                    }
                    else if (i == 3)
                    {
                        if (StringDataExtenso != null)
                        {
                            StringDataExtenso += " e ";
                            StringDataExtenso += lista[i];
                            StringDataExtenso += DeveSerUmUma(i) ? " Dias" : " Dia";
                        }
                        else
                        {
                            StringDataExtenso += lista[i];
                            StringDataExtenso += DeveSerUmUma(i) ? " Dias" : " Dia";
                        }
                    }
                }
            }
        }

        private bool DeveSerUmUma(int i)
        {
            return !(lista[i] == "Um" || lista[i] == "Uma");
        }
        private void PreencherListaTempos()
        {
            for (int i = 0; i < 4; i++)
            {
                lista.Add("0");
            }
        }
        private void DivirDiasDataEmTemposNaLista()
        {
            if (DiasPassados >= 365)
            {
                lista[0] = Convert.ToString(DiasPassados / 365);
                DiasPassados = DiasPassados % 365;
            }
            if (DiasPassados >= 30)
            {
                lista[1] = Convert.ToString(DiasPassados / 30);
                DiasPassados = DiasPassados % 30;
            }
            if (DiasPassados >= 7)
            {
                lista[2] = Convert.ToString(DiasPassados / 7);
                DiasPassados = DiasPassados % 7;
            }
            if (DiasPassados != 0 && DiasPassados < 7)
            {
                lista[3] = Convert.ToString(DiasPassados);
            }
        }
        private void PassarListaParaExtenso()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] != "0" && lista[i] != "")
                {
                    if (i == 2)
                    {
                        lista[i] = PegarTextoSemana(Convert.ToInt32(lista[i]));
                    }
                    else lista[i] = PegarTextoNormal(Convert.ToInt32(lista[i]));
                }
            }
        }
        private string PegarTextoSemana(int identificador)
        {
            switch (identificador)
            {
                case 1: return "Uma";
                case 2: return "Duas";
                default: return PegarTextoNormal(identificador);
            }
        }
        private string PegarTextoNormal(int identificador)
        {
            switch (identificador)
            {
                case 0: return "Zero";
                case 1: return "Um";
                case 2: return "Dois";
                case 3: return "Tres";
                case 4: return "Quatro";
                case 5: return "Cinco";
                case 6: return "Seis";
                case 7: return "Sete";
                case 8: return "Oito";
                case 9: return "Nove";
                case 10: return "Dez";
                case 11: return "Onze";
                case 12: return "Doze";
                case 13: return "Treze";
                case 14: return "Quatorze";
                case 15: return "Quinze";
                case 16: return "Dezesseis";
                case 17: return "Dezessete";
                case 18: return "Dezoito";
                case 19: return "Dezenove";
                case 20: return "Vinte";
                case 21: return "Vinte e Um";
                case 22: return "Vinte e Dois";
                case 23: return "Vinte e Três";
                case 24: return "Vinte e Quatro";
                case 25: return "Vinte e Cinco";
                case 26: return "Vinte e Seis";
                case 27: return "Vinte e Sete";
                case 28: return "Vinte e Oito";
                case 29: return "Vinte e Nove";
                case 30: return "Trinta";
                case 31: return "Trinta e Um";
                case 32: return "Trinta e Dois";
                case 33: return "Trinta e Três";
                case 34: return "Trinta e Quatro";
                case 35: return "Trinta e Cinco";
                case 36: return "Trinta e Seis";
                case 37: return "Trinta e Sete";
                case 38: return "Trinta e Oito";
                case 39: return "Trinta e Nove";
                case 40: return "Quarenta";
                case 41: return "Quarenta e Um";
                case 42: return "Quarenta e Dois";
                case 43: return "Quarenta e Três";
                case 44: return "Quarenta e Quatro";
                case 45: return "Quarenta e Cinco";
                case 46: return "Quarenta e Seis";
                case 47: return "Quarenta e Sete";
                case 48: return "Quarenta e Oito";
                case 49: return "Quarenta e Nove";
                case 50: return "Cinquenta";
                case 51: return "Cinquenta e Um";
                case 52: return "Cinquenta e Dois";
                case 53: return "Cinquenta e Três";
                case 54: return "Cinquenta e Quatro";
                case 55: return "Cinquenta e Cinco";
                case 56: return "Cinquenta e Seis";
                case 57: return "Cinquenta e Sete";
                case 58: return "Cinquenta e Oito";
                case 59: return "Cinquenta e Nove";
                default: return "";
            }
        }

        private string tempo()
        {
            TimeSpan diasEmAberto = dataFixa - DataDesejada;         //DateTime.Now - DataDesejada;

            if (diasEmAberto < new TimeSpan())
            {
                return "0";
            }

            return diasEmAberto.ToString("dd");
        }
    }
}