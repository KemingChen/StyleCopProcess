using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StyleCopProcess
{
    public class Review
    {
        OrderedSet<String> _decriptionList = new OrderedSet<String>();

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

        public String Description
        {
            get
            {
                string output = "";
                foreach (String description in _decriptionList)
                {
                    output += description;
                }
                return output;           
            }
        }

        public void AddDescription(String description)
        {
            _decriptionList.Add(description);
        }

        public bool Equals(Review review)
        {
            return File == review.File && Line == review.Line;
        }

        public bool Equals(Review review1, Review review2)
        {
            return review2.File == review1.File && review2.Line == review1.Line;
        }
    }
}