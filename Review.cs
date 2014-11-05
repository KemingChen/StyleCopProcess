using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StyleCopProcess
{
    public class Review
    {
        String _itemClassName;
        List<int> _itemList = new List<int>();

        public int ReviewId
        {
            get;
            set;
        }

        public int Line
        {
            get;
            set;
        }

        public String File
        {
            get;
            set;
        }

        public String Project
        {
            get;
            set;
        }

        public String ClassName
        {
            get 
            {
                return _itemClassName;
            }
        }

        public String Description
        {
            get
            {
                string output = String.Empty;
                _itemList = _itemList.Distinct().ToList();
                _itemList.Sort();
                foreach (int item in _itemList)
                {
                    output += "-" + Convert.ToString(item);
                }
                return _itemClassName +　output;           
            }
        }

        public void AddDescription(String description)
        {
            String[] array = description.Split('-');
            _itemClassName = array[0];
            if (array.Length > 1)
            {
                int item = Convert.ToInt32(array[1]);
                _itemList.Add(item);
            }
        }

        public bool Equals(Review review)
        {
            return Equals(this, review);
        }

        public bool Equals(Review review1, Review review2)
        {
            return review2.File == review1.File && review2.Line == review1.Line && review2.ClassName == review1.ClassName;
        }
    }
}