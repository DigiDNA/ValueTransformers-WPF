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
