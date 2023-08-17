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
    public class BySubtracting
    {
        private readonly ValueTransformers.BySubtracting Converter = new ValueTransformers.BySubtracting();

        [TestMethod]
        public void TestType()
        {
            Assert.IsTrue( this.Converter.Convert( 1.0, typeof( int ), 1.0, null ) is int );
            Assert.IsTrue( this.Converter.Convert( 1, typeof( float ), 1, null ) is float );
        }

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual( 42, this.Converter.Convert( 42, typeof( int ), 0, null ) );
            Assert.AreEqual( 41, this.Converter.Convert( 42, typeof( int ), 1, null ) );
            Assert.AreEqual( 40, this.Converter.Convert( 42, typeof( int ), 2, null ) );
            Assert.AreEqual( 43, this.Converter.Convert( 42, typeof( int ), -1, null ) );
            Assert.AreEqual( 44, this.Converter.Convert( 42, typeof( int ), -2, null ) );
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
