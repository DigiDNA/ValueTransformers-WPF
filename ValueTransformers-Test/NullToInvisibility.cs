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
    [ TestClass ]
    public class NullToInvisibility
    {
        private readonly ValueTransformers.NullToInvisibility Converter = new ValueTransformers.NullToInvisibility();
        
        [ TestMethod ]
        public void TestNotNull()
        {
            Assert.AreEqual( Visibility.Visible, this.Converter.Convert( "helo world", typeof( Visibility ), null, null ) );
        }

        [ TestMethod ]
        public void TestNull()
        {
            Assert.AreEqual( Visibility.Hidden,    this.Converter.Convert( null, typeof( Visibility ), null, null ) );
            Assert.AreEqual( Visibility.Collapsed, this.Converter.Convert( null, typeof( Visibility ), "collapsed", null ) );
        }

        [ TestMethod ]
        public void TestBadType()
        {
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( null, typeof( string ), null, null ) );
        }
    }
}
