/*******************************************************************************
 * The MIT License (MIT)
 * 
 * Copyright (c) 2021 DigiDNA - www.imazing.com
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ******************************************************************************/

using System;
using System.Windows;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValueTransformers_Test
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
