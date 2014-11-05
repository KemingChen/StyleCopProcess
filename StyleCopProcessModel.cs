using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StyleCopProcess
{
    public class StyleCopProcessModel
    {
        private Dictionary<string, string> _descriptionDictionary = new Dictionary<string, string>()
        {
            {"SA1001 : CSharp.Spacing : Invalid spacing around the comma.","空白與空行-1"},
            {"SA1009 : CSharp.Spacing : Invalid spacing around the closing parenthesis.","空白與空行-15"},
            {"SA1020 : CSharp.Spacing : Invalid spacing around the increment or decrement symbol.","空白與空行-15"},
            {"SA1025 : CSharp.Spacing : The code contains multiple spaces in a row. Only one space is needed.","空白與空行-15"},
            {"SA1000 : CSharp.Spacing : The spacing around the keyword 'for' is invalid.","空白與空行-3"},
            {"SA1000 : CSharp.Spacing : The spacing around the keyword 'if' is invalid.","空白與空行-3"},
            {"SA1000 : CSharp.Spacing : The spacing around the keyword 'switch' is invalid.","空白與空行-3"},
            {"SA1000 : CSharp.Spacing : The spacing around the keyword 'foreach' is invalid.","空白與空行-3"},
            {"SA1000 : CSharp.Spacing : The spacing around the keyword 'while' is invalid.","空白與空行-3"},
            {"SA1002 : CSharp.Spacing : Invalid spacing around the semicolon.","空白與空行-15"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '-' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '^' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '&' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '|' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '>>' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '<<' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '&&' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '||' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '==' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '<' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '!=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '<=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '>' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '>=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '+=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '-=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '/=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '*=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '>>=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '<<=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '&=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '|=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '^=' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '+' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '*' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '/' is invalid.","空白與空行-7"},
            {"SA1003 : CSharp.Spacing : The spacing around the symbol '%' is invalid.","空白與空行-7"},
            {"SA1013 : CSharp.Spacing : Invalid spacing around the closing curly bracket.","空白與空行"},
            
            {"Variable1","變數-1"},
            {"Variable2","變數-2"},
            {"Function1","函式-1"},
            {"ClassDeclaration1","類別宣告-1"}
        };

        private static int DESCRIPTION_COLUMN = 2;
        private static int UNPROCESS_FILE_NAME_COLUMN = 3;
        private static int LINE_COLUMN = 4;
        private static int PROJECT_NAME_COLUMN = 6;
        internal void process(string fileName, string warningMessages)
        {
            List<Review> reviewList = getReviewList(warningMessages);
            saveHtmlFile(fileName, reviewList);
        }

        private void saveHtmlFile(string fileName, List<Review> reviewList)
        {
            StreamWriter streamWriter = new StreamWriter(fileName, false);
            String head = "<html>  <head>    <title>Code Review :: </title>    <style type=\"text/css\">    .body{background-color:White;}    .summary{width:100%;font-weight:bold;background-color:White;border: thin solid #808000;color:#FAFCFE}    .outer{font-weight:normal;color:#6D5757;background-color:#FFDFBF}    .inner{font-weight:normal;color:black;}    .reviewTable{border: thin solid #C0C0C0; width:100%}    .headerRow{color:white;background-color: #800000;font-weight:bold;text-align: center}    .reviewRow{background-color:#FFDFBF;color:black;}    .rAligned{text-align:right;}    .data{visibility:hidden}  </style>  </head>  <body class=\"body\">    <div class=\"summary\">    </div>    <div>      <br />    Created with <a href=\"http://visualstudiogallery.msdn.microsoft.com/d1e40c49-da36-42a5-8d5a-4ebe1feabbc9\">ReviewPal</a></div>    <div class=\"data\">      <Data id=\"ReviewPalData\">        <CodeReview xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Reviews>";
            String foot = "</Reviews>        </CodeReview>      </Data>    </div>  </body></html>";
            streamWriter.WriteLine(head);
            foreach (Review review in reviewList)
            {
                streamWriter.WriteLine("<Review>");
                streamWriter.WriteLine(String.Format("<ReviewId>{0}</ReviewId>", reviewList.IndexOf(review)));
                streamWriter.WriteLine(String.Format("<Line>{0}</Line>", review.Line));
                streamWriter.WriteLine(String.Format("<File>{0}</File>", review.File));
                streamWriter.WriteLine(String.Format("<Project>{0}</Project>", review.Project));
                streamWriter.WriteLine("<Status>Open</Status>");
                streamWriter.WriteLine("<Comment>Suggestion</Comment>");
                streamWriter.WriteLine(String.Format("<Description>{0}</Description>", review.Description));
                streamWriter.WriteLine("<Severity>Minor</Severity>");
                streamWriter.WriteLine("<DefectType>Inconsistent coding standard</DefectType>");
                streamWriter.WriteLine("<InjectedPhase>Implementation</InjectedPhase>");
                streamWriter.WriteLine("<RevieweeComment />");
                streamWriter.WriteLine("<ReExamined>No</ReExamined>");
                streamWriter.WriteLine("<ReviewerComment />");
                streamWriter.WriteLine("</Review>");
            }
            streamWriter.WriteLine(foot);
            streamWriter.Close();
        }

        private List<Review> getReviewList(string warningMessages)
        {
            List<Review> reviewList = new List<Review>();
            string[] warningMessageArray = warningMessages.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string warningMessage in warningMessageArray)
            {
                if (warningMessage == String.Empty)
                    continue;
                string[] warningMessageColumns = warningMessage.Split('\t');
                string warning = warningMessageColumns[DESCRIPTION_COLUMN];
                string unprocessedFileName = warningMessageColumns[UNPROCESS_FILE_NAME_COLUMN];
                int line = Convert.ToInt32(warningMessageColumns[LINE_COLUMN]);
                string projectName = warningMessageColumns[PROJECT_NAME_COLUMN];
                string description = getDescription(warning);
                string fileName = getFileName(unprocessedFileName);

                if (!fileName.Contains(".Designer.cs") || warning.Contains("Variable") || warning.Contains("Function") || warning.Contains("ClassDeclaration"))
                {
                    Review review = new Review();
                    review.AddDescription(description);
                    review.File = fileName;
                    review.Line = line;
                    review.Project = projectName;
                    addReview(reviewList, review);
                }
            }
            return reviewList;
        }

        private void addReview(List<Review> reviewList, Review addReview)
        {
            foreach (Review review in reviewList)
            {
                if (review.Equals(addReview))
                {
                    review.AddDescription(addReview.Description);
                    return;
                }
            }
            reviewList.Add(addReview);
        }

        private string getFileName(string unprocessedFileName)
        {
            string[] splittedUnprocessedFileName = unprocessedFileName.Split('\\');
            return splittedUnprocessedFileName.Last<string>();
        }

        private string getDescription(string warning)
        {
            if (_descriptionDictionary.ContainsKey(warning))
            {
                return _descriptionDictionary[warning];
            }
            return String.Empty;
        }
    }
}