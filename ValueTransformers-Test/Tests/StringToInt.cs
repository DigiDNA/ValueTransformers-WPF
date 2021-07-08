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
    public class StringToInt
    {
        private readonly ValueTransformers.StringToInt Converter = new ValueTransformers.StringToInt();

        [TestMethod]
        public void TestNull()
        {
            Assert.AreEqual( 0, this.Converter.Convert( null, typeof( int ), null, null ) );
            Assert.AreEqual( 0, this.Converter.Convert( null, typeof( int ), null, null ) );

            Assert.AreEqual( "", this.Converter.Convert( null, typeof( string ), null, null ) );
            Assert.AreEqual( "", this.Converter.Convert( null, typeof( string ), null, null ) );
        }

        [TestMethod]
        public void TestEmptyString()
        {
            Assert.AreEqual( 0, this.Converter.Convert( "", typeof( int ), null, null ) );
            Assert.AreEqual( 0, this.Converter.Convert( "", typeof( int ), null, null ) );
        }

        [TestMethod]
        public void TestString()
        {
            Assert.AreEqual(  42, this.Converter.Convert( "42", typeof( int ), null, null ) );
            Assert.AreEqual( -42, this.Converter.Convert( "-42", typeof( int ), null, null ) );
            Assert.AreEqual(   0, this.Converter.Convert( "hello, world", typeof( int ), null, null ) );
            Assert.AreEqual(   0, this.Converter.Convert( "42.0", typeof( int ), null, null ) );
            
            Assert.AreEqual( "42",  this.Converter.Convert(  42, typeof( string ), null, null ) );
            Assert.AreEqual( "-42", this.Converter.Convert( -42, typeof( string ), null, null ) );
        }

        [TestMethod]
        public void TestBadType()
        {
            Assert.ThrowsException<ArgumentException>( () => this.Converter.Convert( null, typeof( object ), null, null ) );
        }

        [TestMethod]
        public void TestConvertBackNull()
        {
            Assert.AreEqual( "", this.Converter.ConvertBack( null, typeof( string ), null, null ) );
            Assert.AreEqual( "", this.Converter.ConvertBack( null, typeof( string ), null, null ) );

            Assert.AreEqual( 0, this.Converter.ConvertBack( null, typeof( int ), null, null ) );
            Assert.AreEqual( 0, this.Converter.ConvertBack( null, typeof( int ), null, null ) );
        }

        [TestMethod]
        public void TestConvertBack()
        {
            Assert.AreEqual( "42",  this.Converter.ConvertBack(  42, typeof( string ), null, null ) );
            Assert.AreEqual( "-42", this.Converter.ConvertBack( -42, typeof( string ), null, null ) );

            Assert.AreEqual(  42, this.Converter.ConvertBack( "42", typeof( int ), null, null ) );
            Assert.AreEqual( -42, this.Converter.ConvertBack( "-42", typeof( int ), null, null ) );
            Assert.AreEqual(   0, this.Converter.ConvertBack( "hello, world", typeof( int ), null, null ) );
            Assert.AreEqual(   0, this.Converter.ConvertBack( "42.0", typeof( int ), null, null ) );
        }

        [TestMethod]
        public void TestConvertBackBadType()
        {
            Assert.ThrowsException<ArgumentException>( () => this.Converter.ConvertBack( null, typeof( object ), null, null ) );
        }
    }
}