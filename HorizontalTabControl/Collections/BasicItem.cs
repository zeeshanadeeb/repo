using HorizontalTabControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizontalTabControl.Collections
{
    public class BasicItem : IBasicItem
    {

        private object m_Id;
        private string m_Name;
        private string m_IconKey;

        public object Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public string IconKey
        {
            get
            {
                return m_IconKey;
            }
            set
            {
                m_IconKey = value;
            }
        }
    }
}
