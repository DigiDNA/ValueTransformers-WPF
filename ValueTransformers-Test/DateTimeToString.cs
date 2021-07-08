/*******************************************************************************
 * Copyright (c) 2019, DigiDNA
 * All rights reserved
 * 
 * Unauthorised copying of this copyrighted work, via any medium is strictly
 * prohibited.
 * Proprietary and confidential.
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
