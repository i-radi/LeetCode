public class Solution {
        public bool IsValid(string code)
        {
            var count = 0; //tag count
            var stack = new Stack<Tag>();
            var tagname = new Stack<int>();
            var isCDataProcessing = false;
            for (var i = 0; i < code.Length; i++)
            {
                if (code[i] == ' ') continue;
                var sub = code.Substring(i);
                if (isCDataProcessing)
                {
                    if (sub.StartsWith("]]>"))
                    {
                        isCDataProcessing = false;
                        i += 2;
                        continue;
                    }
                }
                else
                {
                    if (sub.StartsWith("<![CDATA["))
                    {
                        if (stack.Count == 0) return false;

                        isCDataProcessing = true;
                        i += 8;
                        continue;
                    }

                    if (code[i] == '<')
                    {
                        var next = code.IndexOf('>', i + 1);
                        if (next <= 0) return false;

                        var name = code.Substring(i + 1, next - (i + 1));
                        if (name.Length < 1) return false;
                        if (code[i + 1] == '/')
                        {
                            name = name.Substring(1);
                            //end tag

                            if (stack.Count == 0) return false;
                            var tag = stack.Pop();
                            if (!tag.TagName.Equals(name)) return false;
                        }
                        else
                        {
                            if (count > 0 && stack.Count == 0) return false;

                            //start tag
                            var tag = new Tag()
                            {
                                TagName = name,
                            };
                            stack.Push(tag);
                            count++;
                        }
                        if (!ValidateTagName(name)) return false;
                        i = next;
                    }
                    else if (count==0)
                    {
                        return false;
                    }
                    else if (stack.Count == 0)
                    {
                        return false;
                    }
                }
            }

            return stack.Count ==0 ;
        }


        /// <summary>
        /// rule3: A valid TAG_NAME only contain upper-case letters, and has length in range [1,9]. Otherwise, the TAG_NAME is invalid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ValidateTagName(string name)
        {
            foreach(var n in name)
            {
                if (!(n >= 'A' && n <= 'Z')) return false;
            }
            return name.Length > 0 && name.Length < 10 && name.Equals(name.ToUpper());
        }
        public class Tag
        {
            public string TagName;
            public string TagValue;

        }
}