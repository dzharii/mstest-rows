use strict; use warnings;


my $namespace_template = <<'EOL';
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestRows.Rows
{
%%= PUT TEST CLASSES HERE =%%
}
EOL


my $test_class_template =<<'EOL';
    [TestClass]
    public abstract class TestRows_%%= NUMBER OF TESTS =%%<DATAROW> : TestBase<DATAROW>
    {
%%= PUT TESTS HERE =%%
    }
EOL


my $test_method_template =<<'EOL';
        [TestMethod]
        public void TestRow_%%= TEST NUMBER =%%()
        {
            TestRowImplementation(%%= TEST NUMBER =%%);
        }
EOL


my @test_classes;

for my $rows (1..100) {
    
    my @generated_methods = ();

    for my $test_case (1..$rows) {
        my $method_template = $test_method_template;
        
        $method_template =~ s/%%= TEST NUMBER =%%/sprintf("%02d", $test_case)/gse;
        push @generated_methods, $method_template;
    }
    
    my $method_generation_result = join "\n", @generated_methods;

    my $class_template = $test_class_template;
    
    $class_template =~ s/%%= NUMBER OF TESTS =%%/sprintf("%02d", $rows)/gse;
    $class_template =~ s/%%= PUT TESTS HERE =%%/$method_generation_result/gs;

    push @test_classes, $class_template;

}

my $all_classes_in_namespace = join "\n", @test_classes;

$namespace_template =~ s/%%= PUT TEST CLASSES HERE =%%/$all_classes_in_namespace/gs;

open (GOVNOKOD, '>', '../TestRows.cs') or die("Cannot write to '../TestRows.cs'\n $!");
print GOVNOKOD $namespace_template;
close GOVNOKOD;


