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

namespace ValueTransformers_Test
{
    [TestClass]
    public class BytesToString
    {
        private readonly ValueTransformers.BytesToString Converter = new ValueTransformers.BytesToString();

        [TestMethod]
        public void TestBadType()
        {
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( 1024, typeof( double ), null, null ) );
        }

        [TestMethod]
        public void TestconvertBack()
        {
            Assert.ThrowsException< NotSupportedException >( () => this.Converter.ConvertBack( "1.00 KB", typeof( ulong ), null, null ) );
        }

        [TestMethod]
        public void TestNull()
        {
            Assert.IsNull( this.Converter.Convert( null, typeof( string ), null, null ) );
        }

        [TestMethod]
        public void TestBinary()
        {
            Assert.AreEqual( "10 bytes", this.Converter.Convert( 10, typeof( string ), null, null ) );
            Assert.AreEqual( "1.00 KB", this.Converter.Convert( 1024, typeof( string ), null, null ) );
            Assert.AreEqual( "1.00 MB", this.Converter.Convert( 1024 * 1024, typeof( string ), null, null ) );
            Assert.AreEqual( "1.00 GB", this.Converter.Convert( 1024 * 1024 * 1024, typeof( string ), null, null ) );
            Assert.AreEqual( "1.00 TB", this.Converter.Convert( ( ulong )1024 * 1024 * 1024 * 1024, typeof( string ), null, null ) );
        }

        [TestMethod]
        public void TestDecimal()
        {
            Assert.AreEqual( "10 bytes", this.Converter.Convert( 10, typeof( string ), "decimal", null ) );
            Assert.AreEqual( "24 bytes", this.Converter.Convert( 24, typeof( string ), "decimal", null ) );

            Assert.AreEqual( "1.00 KB", this.Converter.Convert( 1000, typeof( string ), "decimal", null ) );
            Assert.AreEqual( "1.02 KB", this.Converter.Convert( 1024, typeof( string ), "decimal", null ) );

            Assert.AreEqual( "1.00 MB", this.Converter.Convert( 1000000, typeof( string ), "decimal", null ) );
            Assert.AreEqual( "1.02 MB", this.Converter.Convert( 1024000, typeof( string ), "decimal", null ) );

            Assert.AreEqual( "1.00 GB", this.Converter.Convert( 1000000000, typeof( string ), "decimal", null ) );
            Assert.AreEqual( "1.02 GB", this.Converter.Convert( 1024000000, typeof( string ), "decimal", null ) );

            Assert.AreEqual( "1.00 TB", this.Converter.Convert( 1000000000000, typeof( string ), "decimal", null ) );
            Assert.AreEqual( "1.02 TB", this.Converter.Convert( 1024000000000, typeof( string ), "decimal", null ) );
        }

        [TestMethod]
        public void TestCustomFormatter()
        {
            ValueTransformers.BytesToString.CustomFormatter = ( bytes, prefix ) => "Foo";

            Assert.AreEqual( "Foo", this.Converter.Convert( 1024, typeof( string ), null, null ) );
            Assert.AreEqual( "Foo", this.Converter.Convert( 2048, typeof( string ), null, null ) );
            
            ValueTransformers.BytesToString.CustomFormatter = ( bytes, prefix ) => "Bar";

            Assert.AreEqual( "Bar", this.Converter.Convert( 1024, typeof( string ), null, null ) );
            Assert.AreEqual( "Bar", this.Converter.Convert( 2048, typeof( string ), null, null ) );

            ValueTransformers.BytesToString.CustomFormatter = null;

            Assert.AreEqual( "1.00 KB", this.Converter.Convert( 1024, typeof( string ), null, null ) );
            Assert.AreEqual( "2.00 KB", this.Converter.Convert( 2048, typeof( string ), null, null ) );
        }
    }
}
