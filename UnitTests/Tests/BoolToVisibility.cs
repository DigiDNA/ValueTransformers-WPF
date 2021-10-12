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

namespace UnitTests
{
    [ TestClass ]
    public class BoolToVisibility
    {
        private readonly ValueTransformers.BoolToVisibility Converter = new ValueTransformers.BoolToVisibility();
        
        [ TestMethod ]
        public void TestTrue()
        {
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( true, typeof( Visibility ), null, null ) );
        }

        [ TestMethod ]
        public void TestFalse()
        {
            Assert.AreEqual( Visibility.Hidden,    this.Converter.Convert( false, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( false, typeof( Visibility ), "collapsed", null ) );
        }

        [ TestMethod ]
        public void TestBadType()
        {
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( false, typeof( string ),     null, null ) );
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( 42,    typeof( Visibility ), null, null ) );
        }
    }
}
