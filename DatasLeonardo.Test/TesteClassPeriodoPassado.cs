using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DatasLeonardo;

namespace DatasLeonardo.Test
{
    [TestClass]
    public class TesteClassPeriodoPassado
    {
        [TestMethod]
        public void DeveRetornarAnoMesSemanaDia()
        {
            PeriodoPassado aux;
            aux = new PeriodoPassado(new DateTime(2001, 08, 17));
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Dezenove Anos, Nove Meses, Duas Semanas e Tres Dias", auxString);

            aux = new PeriodoPassado(new DateTime(2001, 07, 20));
            auxString = aux.StringDataExtenso;
            Assert.AreEqual("Dezenove Anos, Dez Meses, Duas Semanas e Um Dia", auxString);
        }

        [TestMethod]
        public void DeveRetornarAnoMesSemana()
        {
            PeriodoPassado aux;
            aux = new PeriodoPassado(new DateTime(2001, 08, 17));
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Dezenove Anos, Nove Meses, Duas Semanas e Tres Dias", auxString);

            aux = new PeriodoPassado(new DateTime(2001, 07, 21));
            auxString = aux.StringDataExtenso;
            Assert.AreEqual("Dezenove Anos, Dez Meses, Duas Semanas", auxString);
        }

        [TestMethod]
        public void DeveRetornarAnoMes()
        {
            PeriodoPassado aux;
            aux = new PeriodoPassado(new DateTime(2001, 04, 01));
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Vinte Anos, Dois Meses", auxString);
        }

        [TestMethod]
        public void DeveRetornarAno()
        {
            PeriodoPassado aux;
            aux = new PeriodoPassado(new DateTime(2001, 05, 31));
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Vinte Anos", auxString);
        }

        [TestMethod]
        public void DeveRetornarDias()
        {
            PeriodoPassado aux;
            aux = new PeriodoPassado(6);
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Seis Dias", auxString);
        }

        [TestMethod]
        public void DeveRetornarDiasSemanas()
        {
            PeriodoPassado aux;
            aux = new PeriodoPassado(9);
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Uma Semana e Dois Dias", auxString);
        }

        [TestMethod]
        public void DeveRetornarDiasSemanasMes()
        {
            PeriodoPassado aux;
            aux = new PeriodoPassado(39);
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Um Mês, Uma Semana e Dois Dias", auxString);
        }

        [TestMethod]
        public void DeveRetornarDiasSemanasMesAno()
        {
            PeriodoPassado aux;
            aux = new PeriodoPassado(404);
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Um Ano, Um Mês, Uma Semana e Dois Dias", auxString);
        }

        [TestMethod]
        public void DeveRetornarHorasMinutosSegundos()
        {
            PeriodoPassado aux;

            aux = new PeriodoPassado(new DateTime(2021, 05, 26, 14, 48, 48));
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Seis Horas, Onze Minutos e Um Segundo", auxString);

            aux = new PeriodoPassado(new DateTime(2021, 05, 26, 14, 13, 32));
            auxString = aux.StringDataExtenso;
            Assert.AreEqual("Seis Horas, Quarenta e Seis Minutos e Dezessete Segundos", auxString);

            aux = new PeriodoPassado(new DateTime(2021, 05, 26, 03, 03, 03));
            auxString = aux.StringDataExtenso;
            Assert.AreEqual("Dezessete Horas, Cinquenta e Seis Minutos e Quarenta e Seis Segundos", auxString);

            aux = new PeriodoPassado(new DateTime(2021, 05, 26, 19, 58, 48));
            auxString = aux.StringDataExtenso;
            Assert.AreEqual("Uma Hora, Um Minuto e Um Segundo", auxString);
        }

        [TestMethod]
        public void DeveRetornarMinutos()
        {
            PeriodoPassado aux;

            aux = new PeriodoPassado(new DateTime(2021, 05, 26, 20, 58, 49));
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Zero Horas, Um Minuto e Zero Segundos", auxString);     
        }

        [TestMethod]
        public void DeveRetornarHoras()
        {
            PeriodoPassado aux;

            aux = new PeriodoPassado(new DateTime(2021, 05, 26, 19, 59, 49));
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Uma Hora, Zero Minutos e Zero Segundos", auxString);
        }

        [TestMethod]
        public void DeveRetornarSegundos()
        {
            PeriodoPassado aux;

            aux = new PeriodoPassado(new DateTime(2021, 05, 26, 20, 59, 48));
            string auxString = aux.StringDataExtenso;
            Assert.AreEqual("Zero Horas, Zero Minutos e Um Segundo", auxString);
        }
    }
}
