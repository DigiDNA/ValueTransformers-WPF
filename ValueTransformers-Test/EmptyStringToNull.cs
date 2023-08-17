﻿/*******************************************************************************
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
    public class EmptyStringToNull
    {
        private readonly ValueTransformers.EmptyStringToNull Converter = new ValueTransformers.EmptyStringToNull();

        [TestMethod]
        public void TestEmpty()
        {
            Assert.IsNull( this.Converter.Convert( "", typeof( string ), null, null ) );
        }

        [TestMethod]
        public void TestNotEmpty()
        {
            Assert.IsNotNull( this.Converter.Convert( "hello, world", typeof( string ), null, null ) );
        }

        [TestMethod]
        public void TestTrim()
        {
            Assert.IsNull(    this.Converter.Convert( "              ", typeof( string ), "trim", null ) );
            Assert.IsNotNull( this.Converter.Convert( " hello, world ", typeof( string ), "trim", null ) );
        }

        [TestMethod]
        public void TestNull()
        {
            Assert.IsNull( this.Converter.Convert( null, typeof( string ), null, null ) );
        }

        [TestMethod]
        public void TestBadType()
        {
            Assert.ThrowsException<ArgumentException>( () => this.Converter.Convert( false, typeof( string ), null, null ) );
            Assert.ThrowsException<ArgumentException>( () => this.Converter.Convert( "hello, world", typeof( Visibility ), null, null ) );
        }
    }
}