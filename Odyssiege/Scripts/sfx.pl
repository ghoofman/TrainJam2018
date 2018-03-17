
open(SFX, ">sfx.txt");

chdir '../Assets/Resources/sfx';

my @dirs = <*>;
foreach my $dir (@dirs) {
	if (-d $dir) {
		chdir $dir;
		my $lastSfx = "";
		my @items = <*>;
		foreach my $item (@items) {
			# get name without number
			if ($item =~ /^(.*?)\d+\.(mp3|wav|ogg)$/) {
				$sfx = $1;
				if ($sfx ne $lastSfx) {
					if (length $lastSfx) {
						print SFX "			}},\n";
					}
					$lastSfx = $sfx;
					print SFX "			{\"$dir/$lastSfx\", new List<AudioClip>{\n";
				}
				$item =~ s/\.(mp3|wav|ogg)//;
				print SFX "				Resources.Load<AudioClip>(\"sfx/$dir/$item\"),\n";
			} elsif ($item =~ /^(.*?)\.(mp3|wav|ogg)$/) {
				$sfx = $1;
				if ($sfx ne $lastSfx) {
					if (length $lastSfx) {
						print SFX "			}},\n";
					}
					$lastSfx = $sfx;
					print SFX "			{\"$dir/$lastSfx\", new List<AudioClip>{\n";
				}
				$item =~ s/\.(mp3|wav|ogg)//;
				print SFX "				Resources.Load<AudioClip>(\"sfx/$dir/$item\"),\n";
			}
		}
		print SFX "			}},\n";
		chdir '..';
	}
}

close(SFX);
