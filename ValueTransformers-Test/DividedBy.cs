/*******************************************************************************
 * Copyright (c) 2019, DigiDNA
 * All rights reserved
 * 
 * Unauthorised copying of this copyrighted work, via any medium is strictly
 * prohibited.
 * Proprietary and confidential.
 ******************************************************************************/

using System;
using System.Windows;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DividedBy
    {
        private readonly ValueTransformers.DividedBy Converter = new ValueTransformers.DividedBy();

        [TestMethod]
        public void TestType()
        {
            Assert.IsTrue( this.Converter.Convert( 1.0, typeof( int ),   1.0, null ) is int );
            Assert.IsTrue( this.Converter.Convert( 1,   typeof( float ), 1,   null ) is float );
        }

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual( 42, this.Converter.Convert( 42, typeof( int ), 1, null ) );
            Assert.AreEqual( 21, this.Converter.Convert( 42, typeof( int ), 2, null ) );
        }

        [TestMethod]
        public void TestZero()
        {
            Assert.IsTrue( double.IsInfinity( Convert.ToDouble( this.Converter.Convert( 42, typeof( double ), 0, null ) ) ) );
        }

        [TestMethod]
        public void TestNullValue()
        {
            Assert.AreEqual( null, this.Converter.Convert( null, typeof( int ), 1, null ) );
        }

        [TestMethod]
        public void TestNullParameter()
        {
            Assert.AreEqual( 42, this.Converter.Convert( 42, typeof( int ), null, null ) );
        }
    }
}
