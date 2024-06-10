# regex_speed_test.pl

use strict;
use warnings;
use Time::HiRes qw(time);

my $start_time = time;

open(my $file, "<", "emails.txt") or die "Could not open file: $!";
my $content = do { local $/; <$file> };
close($file);

my $pattern = qr/[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}/;
my @matches = $content =~ /$pattern/g;

my $end_time = time;
my $elapsed_time = $end_time - $start_time;

print "Found " . scalar(@matches) . " email addresses\n";
print "Elapsed time: $elapsed_time seconds\n";

