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
    [ TestClass ]
    public class BoolToInvisibility
    {
        private readonly ValueTransformers.BoolToInvisibility Converter = new ValueTransformers.BoolToInvisibility();
        
        [ TestMethod ]
        public void TestFalse()
        {
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( false, typeof( Visibility ), null, null ) );
        }

        [ TestMethod ]
        public void TestTrue()
        {
            Assert.AreEqual( Visibility.Hidden,    this.Converter.Convert( true, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( true, typeof( Visibility ), "collapsed", null ) );
        }

        [ TestMethod ]
        public void TestBadType()
        {
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( false, typeof( string ),     null, null ) );
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( 42,    typeof( Visibility ), null, null ) );
        }
    }
}
