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

namespace UnitTests
{
    [ TestClass ]
    public class IsZeroToVisibility
    {
        private readonly ValueTransformers.IsZeroToVisibility Converter = new ValueTransformers.IsZeroToVisibility();
        
        [ TestMethod ]
        public void TestZero()
        {
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( char    )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( sbyte   )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( byte    )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( short   )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( ushort  )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( int     )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( uint    )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( long    )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( ulong   )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( float   )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( double  )0, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( ( decimal )0, typeof( Visibility ), null, null ) );
        }

        [ TestMethod ]
        public void TestNotZero()
        {
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( char    )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( sbyte   )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( byte    )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( short   )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( ushort  )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( int     )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( uint    )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( long    )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( ulong   )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( float   )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( double  )42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( decimal )42, typeof( Visibility ), null, null ) );

            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( sbyte   )-42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( short   )-42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( int     )-42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( long    )-42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( float   )-42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( double  )-42, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Hidden, this.Converter.Convert( ( decimal )-42, typeof( Visibility ), null, null ) );
            
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( char    )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( sbyte   )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( byte    )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( short   )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( ushort  )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( int     )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( uint    )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( long    )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( ulong   )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( float   )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( double  )42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( decimal )42, typeof( Visibility ), "collapsed", null ) );

            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( sbyte   )-42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( short   )-42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( int     )-42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( long    )-42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( float   )-42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( double  )-42, typeof( Visibility ), "collapsed", null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( ( decimal )-42, typeof( Visibility ), "collapsed", null ) );
}

        [ TestMethod ]
        public void TestNull()
        {
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( null, typeof( Visibility ), null, null ) );
        }

        [ TestMethod ]
        public void TestBadType()
        {
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( "hello, world", typeof( Visibility ), null, null ) );
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( 0,              typeof( bool ),       null, null ) );
        }
    }
}
