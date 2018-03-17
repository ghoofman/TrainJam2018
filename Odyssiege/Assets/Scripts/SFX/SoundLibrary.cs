﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class SoundLibrary {
	public static Dictionary<string, List<AudioClip>> GetLibrary() {
		return new Dictionary<string, List<AudioClip>> {
		///////// PASTE CODE OUTPUT HERE /////////
			{"Axe/AxeDrag", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Axe/AxeDrag"),
            }},
            {"Axe/AxeHighImpact", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Axe/AxeHighImpact"),
            }},
            {"Axe/AxeLowImpact", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Axe/AxeLowImpact"),
            }},
            {"Axe/AxeMidImpact", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Axe/AxeMidImpact"),
            }},
            {"Axe/AxeSwingWDirt", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Axe/AxeSwingWDirt"),
            }},
            {"Bow/ArrowImpact", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Bow/ArrowImpact"),
            }},
            {"Bow/ArrowLaunch", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Bow/ArrowLaunch"),
            }},
            {"Bow/BowExplosion", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Bow/BowExplosion"),
            }},
            {"Enemy/Dog", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Enemy/Dog1"),
                Resources.Load<AudioClip>("sfx/Enemy/Dog2"),
                Resources.Load<AudioClip>("sfx/Enemy/Dog3"),
            }},
            {"Enemy/DogFiveBark", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Enemy/DogFiveBark"),
            }},
            {"Enemy/DogThreeBark", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Enemy/DogThreeBark"),
            }},
            {"Enemy/EnemyBurningHorse", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Enemy/EnemyBurningHorse"),
            }},
            {"Enemy/EnemyMarchLoop", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Enemy/EnemyMarchLoop"),
            }},
            {"Enemy/EnemySpearHit", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Enemy/EnemySpearHit1"),
            }},
            {"Enemy/EnemyTorchSwing", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Enemy/EnemyTorchSwing"),
            }},
            {"Environment/RockCrumbleLrg", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Environment/RockCrumbleLrg1"),
            }},
            {"Environment/RockCrumbleMed", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Environment/RockCrumbleMed1"),
                Resources.Load<AudioClip>("sfx/Environment/RockCrumbleMed2"),
                Resources.Load<AudioClip>("sfx/Environment/RockCrumbleMed3"),
                Resources.Load<AudioClip>("sfx/Environment/RockCrumbleMed4"),
                Resources.Load<AudioClip>("sfx/Environment/RockCrumbleMed5"),
            }},
            {"Environment/RockCrumbleSmall", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Environment/RockCrumbleSmall1"),
                Resources.Load<AudioClip>("sfx/Environment/RockCrumbleSmall2"),
                Resources.Load<AudioClip>("sfx/Environment/RockCrumbleSmall3"),
            }},
            {"Environment/SoilImpact", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Environment/SoilImpact"),
            }},
            {"Gore/GoreAxe", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Gore/GoreAxe"),
            }},
            {"Gore/GoreBasicArrow-(todo-fix)", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Gore/GoreBasicArrow-(todo-fix)"),
            }},
            {"Gore/GoreExplosion", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Gore/GoreExplosion"),
            }},
            {"Gore/GoreLazer", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Gore/GoreLazer"),
            }},
            {"Gore/GoreMace", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Gore/GoreMace"),
            }},
            {"Gore/GoreMeteor", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Gore/GoreMeteor"),
            }},
            {"Laser/LazerEyes", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Laser/LazerEyes"),
            }},
            {"Mace/MaceDragLoop", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Mace/MaceDragLoop"),
            }},
            {"Mace/MaceHighImpact", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Mace/MaceHighImpact"),
            }},
            {"Mace/MaceHighImpactSwish", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Mace/MaceHighImpactSwish"),
            }},
            {"Mace/MaceLowImpact", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Mace/MaceLowImpact"),
            }},
            {"Mace/MaceMidImpact", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Mace/MaceMidImpact"),
            }},
            {"MeteorHatch/AssHatchClose", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/MeteorHatch/AssHatchClose"),
            }},
            {"MeteorHatch/AssHatchOpen", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/MeteorHatch/AssHatchOpen"),
            }},
            {"MeteorHatch/MeteorSequence", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/MeteorHatch/MeteorSequence"),
            }},
            {"UI/MenuButtonHover", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/UI/MenuButtonHover"),
            }},
            {"UI/MenuStartGameButton", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/UI/MenuStartGameButton"),
            }},
            {"Wheels/Wheel", new List<AudioClip>{
                Resources.Load<AudioClip>("sfx/Wheels/Wheel1"),
                Resources.Load<AudioClip>("sfx/Wheels/Wheel2"),
                Resources.Load<AudioClip>("sfx/Wheels/Wheel3"),
                Resources.Load<AudioClip>("sfx/Wheels/Wheel4"),
                Resources.Load<AudioClip>("sfx/Wheels/Wheel5"),
                Resources.Load<AudioClip>("sfx/Wheels/Wheel6"),
                Resources.Load<AudioClip>("sfx/Wheels/Wheel7"),
            }},
		///////// END CODE OUTPUT /////////
		};
	}
}