Ms-Test Rows
===========

Insane MS Tests Rows implementation for Data-Driven tests with generated code and inherence! 

Problem 
--------
Comparing to NUnit or MbUnit, Visual Studio Test Framework (aka MS-Test) has limited possibilities to re-run data-driven tests. Basically, you can create a data-driven test, but MS-Test will consider all the data rows as single test. That means if at least 1 row from 100 fails – all the entire test will be reported as “Failed”.   
That might be fine for fast unit test – you may fix the issue and re-run all the rows in a few seconds...  
But, when we are talking about much slower User Acceptance Tests based on Selenium WebDriver – it might take a few hours to re-run all the rows.  
And there is no possibility just to re-run an individual one. Such behavior is just painful.  

Solution
--------
I’ve found only one solution that does shit well. The only thing you have to do is just include 2 files into our solution and subclass one of the generated TestClasses which has a required number of generated TestMethods inside.  
Yes, TestRows.cs has 30 KLOC of silly generated code inside. So, if you are not scared yet, then follow the instructions below.  

Tutorial 
--------
Download files [TestBase.cs] (https://github.com/dzhariy/mstest-rows/raw/master/TestBase.cs) and [TestRows.cs] (https://github.com/dzhariy/mstest-rows/raw/master/TestRows.cs) and include them into your test project.  
All logic is implemented in TestBase.cs, so you may change it anytime.  
Now create your own test class, and subclass one of the classes that live in the namespace “MsTestRows.Rows.*”.  
 
In your derived class, you have to implement 2 abstract methods:  

**GetNextDataRow(int rowNumber)** – returns a data row  

**TestMethod – (T dataRow, int rowNumber)** – your actual data-driven test implementation which will be called for each data row.  
 
In the example below, the Ha_ha_ha_Test subclasses TestRows_42 and has 42 methods inside:
``` csharp

    [TestClass]
    public class Ha_ha_ha_Test: MsTestRows.Rows.TestRows_42<string>
    {
        public override void TestMethod(string dataRow, int rowNumber)
        {
            Console.WriteLine(dataRow);
            Assert.IsFalse(dataRow.Contains("3"));
        }

        public override string GetNextDataRow(int rowNumber)
        {
            return "data" + rowNumber;
        }
    }

```

The TestRows.cs  file size is 30 KLOC which I have generated in less than one second.  
I’ve never been so productive! 

And... yes, the code generator is written in Perl.  
Just because it is the best language to solve insane problems!  
``` perl
    "use Perl" or die;
```

License: Unlicense
--------
This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org/>

Contribution
--------
I do not accept patches and pull requests for this project.  
Just grab the code and do whatever you want. :D  
   
![Counter](https://http://www.e-zeeinternet.com/count.php?page=997378&style=big_block&nbdigits=5)
