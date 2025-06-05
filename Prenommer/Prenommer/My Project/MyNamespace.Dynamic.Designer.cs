using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Prenommer.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public About m_About;

            public About About
            {
                [DebuggerHidden]
                get
                {
                    m_About = Create__Instance__(m_About);
                    return m_About;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_About))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_About);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Append m_Append;

            public Append Append
            {
                [DebuggerHidden]
                get
                {
                    m_Append = Create__Instance__(m_Append);
                    return m_Append;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Append))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Append);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Contact m_Contact;

            public Contact Contact
            {
                [DebuggerHidden]
                get
                {
                    m_Contact = Create__Instance__(m_Contact);
                    return m_Contact;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Contact))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Contact);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Create m_Create;

            public Create Create
            {
                [DebuggerHidden]
                get
                {
                    m_Create = Create__Instance__(m_Create);
                    return m_Create;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Create))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Create);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Find m_Find;

            public Find Find
            {
                [DebuggerHidden]
                get
                {
                    m_Find = Create__Instance__(m_Find);
                    return m_Find;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Find))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Find);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Main m_Main;

            public Main Main
            {
                [DebuggerHidden]
                get
                {
                    m_Main = Create__Instance__(m_Main);
                    return m_Main;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Main))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Main);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Popup m_Popup;

            public Popup Popup
            {
                [DebuggerHidden]
                get
                {
                    m_Popup = Create__Instance__(m_Popup);
                    return m_Popup;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Popup))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Popup);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Query m_Query;

            public Query Query
            {
                [DebuggerHidden]
                get
                {
                    m_Query = Create__Instance__(m_Query);
                    return m_Query;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Query))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Query);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public SplashScreen m_SplashScreen;

            public SplashScreen SplashScreen
            {
                [DebuggerHidden]
                get
                {
                    m_SplashScreen = Create__Instance__(m_SplashScreen);
                    return m_SplashScreen;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_SplashScreen))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_SplashScreen);
                }
            }

        }


    }
}