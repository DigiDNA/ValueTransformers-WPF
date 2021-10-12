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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValueTransformers_Test
{
    [TestClass]
    public class DateTimeToString
    {
        private readonly ValueTransformers.DateTimeToString Converter = new ValueTransformers.DateTimeToString();
        private readonly DateTime                           Date      = new DateTime( 1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc );

        [TestMethod]
        public void TestDateTime()
        {
            Assert.AreEqual( "01/01/1970 00:00", this.Converter.Convert( this.Date, typeof( string ), null, null ) );

            Assert.AreEqual( "", this.Converter.Convert( this.Date, typeof( string ), "none", null ) );
            Assert.AreEqual( "01/01/1970 00:00", this.Converter.Convert( this.Date, typeof( string ), "short", null ) );
            Assert.AreEqual( "Thursday, 1 January 1970 00:00:00", this.Converter.Convert( this.Date, typeof( string ), "long", null ) );

            Assert.AreEqual( "", this.Converter.Convert( this.Date, typeof( string ), "none:none", null ) );
            Assert.AreEqual( "01/01/1970", this.Converter.Convert( this.Date, typeof( string ), "short:none", null ) );
            Assert.AreEqual( "Thursday, 1 January 1970", this.Converter.Convert( this.Date, typeof( string ), "long:none", null ) );

            Assert.AreEqual( "", this.Converter.Convert( this.Date, typeof( string ), "none:none", null ) );
            Assert.AreEqual( "00:00", this.Converter.Convert( this.Date, typeof( string ), "none:short", null ) );
            Assert.AreEqual( "00:00:00", this.Converter.Convert( this.Date, typeof( string ), "none:long", null ) );
        }

        [TestMethod]
        public void TestLong()
        {
            TimeSpan diff = this.Date - this.Date.ToLocalTime();
            long     ts   = ( long )Math.Floor( diff.TotalSeconds );

            Assert.AreEqual( "01/01/1970 00:00", this.Converter.Convert( ts, typeof( string ), null, null ) );

            Assert.AreEqual( "", this.Converter.Convert( ts, typeof( string ), "none", null ) );
            Assert.AreEqual( "01/01/1970 00:00", this.Converter.Convert( ts, typeof( string ), "short", null ) );
            Assert.AreEqual( "Thursday, 1 January 1970 00:00:00", this.Converter.Convert( ts, typeof( string ), "long", null ) );

            Assert.AreEqual( "", this.Converter.Convert( ts, typeof( string ), "none:none", null ) );
            Assert.AreEqual( "01/01/1970", this.Converter.Convert( ts, typeof( string ), "short:none", null ) );
            Assert.AreEqual( "Thursday, 1 January 1970", this.Converter.Convert( ts, typeof( string ), "long:none", null ) );

            Assert.AreEqual( "", this.Converter.Convert( ts, typeof( string ), "none:none", null ) );
            Assert.AreEqual( "00:00", this.Converter.Convert( ts, typeof( string ), "none:short", null ) );
            Assert.AreEqual( "00:00:00", this.Converter.Convert( ts, typeof( string ), "none:long", null ) );
        }

        [TestMethod]
        public void TestString()
        {
            Assert.AreEqual( "hello, world", this.Converter.Convert( "hello, world", typeof( string ), null, null ) );
        }

        [ TestMethod ]
        public void TestBadType()
        {
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( this.Date, typeof( bool ),   null, null ) );
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( true,      typeof( string ), null, null ) );
        }
    }
}
