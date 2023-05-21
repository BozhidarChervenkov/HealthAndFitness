namespace HealthAndFitness.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using HealthAndFitness.Models;

    public static class ApplicationDbContextExtension
    {
        private const string AdminId = "3dd43897-b531-464b-a3d4-b50b8c12ce0f";

        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedAdministrator(services);
            SeedContextData(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        public static void SeedContextData(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            // Seeding body muscle groups:
            if (!context.MuscleGroups.Any())
            {
                context.MuscleGroups.AddRange(
                    new MuscleGroup { Name = "Abs" },
                    new MuscleGroup { Name = "Back" },
                    new MuscleGroup { Name = "Biceps" },
                    new MuscleGroup { Name = "Calf" },
                    new MuscleGroup { Name = "Chest" },
                    new MuscleGroup { Name = "Forearms" },
                    new MuscleGroup { Name = "Legs" },
                    new MuscleGroup { Name = "Shoulders" },
                    new MuscleGroup { Name = "Triceps" },
                    new MuscleGroup { Name = "All" }
                    );
            }

            if (!context.Exercises.Any())
            {
                context.Exercises.AddRange(

                    // 3 Abs exercises
                    new Exercise()
                    {
                        Name = "Plank",
                        Description = "The plank is a popular isometric exercise that works every core muscle, as well as muscles in the back, shoulders, hips, and legs. While most traditional core exercises train the core through movement, the plank trains the core to resist movement by keeping the body stable for a period of time.",
                        MuscleGroupId = 1,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=ASdvN_XEl_c&ab_channel=Bowflex"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://blog-images-1.pharmeasy.in/blog/production/wp-content/uploads/2021/01/06152556/3.jpg" },
                        new Image {Url = "https://www.shape.com/thmb/i3tgB5V-vts89WQ0ZzDRB2WUNEM=/1500x0/filters:no_upscale():max_bytes(200000):strip_icc()/30-Day-Plank-Challenge-Stocksy_txp37c4682fMZb300_Medium_3751574-8471c02a2c6f4d959de0e4fc3487238b.jpg" }
                        }
                    },
                    new Exercise()
                    {
                        Name = "Sit ups",
                        Description = "Situps are classic abdominal exercises done by lying on your back and lifting your torso. They use your body weight to strengthen and tone the core-stabilizing abdominal muscles. Situps work the rectus abdominis, transverse abdominis, and obliques in addition to your hip flexors, chest, and neck.",
                        MuscleGroupId = 1,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=jDwoBqPH0jk&ab_channel=Howcast"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://gethealthyu.com/wp-content/uploads/2014/08/Full-Sit-Up_Exercise.jpg" },
                        new Image {Url = "https://fitnessvolt.com/wp-content/uploads/2021/07/janda-sit-up-exercise-guide.jpg" }
                        }
                    },
                    new Exercise()
                    {
                        Name = "Leg Raises",
                        Description = "The leg raise is a strength training exercise which targets the iliopsoas (the anterior hip flexors). Because the abdominal muscles are used isometrically to stabilize the body during the motion, leg raises are also often used to strengthen the rectus abdominis muscle and the internal and external oblique muscles.",
                        MuscleGroupId = 1,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=Cwuxy8eo7iw&ab_channel=WhatsUpDude"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                    new Image {Url = "https://imgk.timesnownews.com/story/leg-raises-exercise.gif" },
                    new Image {Url = "https://i.pinimg.com/originals/f9/d7/a4/f9d7a4536d55e8ac98f4c8fdc41ff13f.jpg" },
                        }
                    },
                    // 3 Back exercises
                    new Exercise()
                    {
                        Name = "Pull ups",
                        Description = "A pullup is a challenging upper body exercise where you grip an overhead bar and lift your body until your chin is above that bar. It's a hard exercise to execute — so hard, in fact, that a U.S. Marine can receive a passing score on the annual physical fitness test without doing pullups at all.",
                        MuscleGroupId = 2,
                        Video = new Video
                        {
                            Url = "https://youtu.be/wuVnNxxk63Q"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://assets.sweat.com/html_body_blocks/images/000/018/760/original/HowToTrainToDoAPullUp_en7521763369b90979a9b9e09ded6c123b.jpg?1597198774" },
                        new Image {Url = "https://blogs.rdxsports.com/wp-content/uploads/2016/05/pull-up-e1568797299481.jpg" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Pull down",
                        Description = "The pulldown exercise works the back muscles and is performed at a workstation with adjustable resistance, usually plates. While seated, you pull a hanging bar toward you to reach chin level, then release it back up with control for one repetition. This exercise can be done as part of an upper-body strength workout.",
                        MuscleGroupId = 2,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=j9jtjL8FhPI&ab_channel=ErinStern"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://image.myupchar.com/9494/webp/Lat_Pulldown.webp" },
                        new Image {Url = "https://www.bodybuilding.com/images/2017/may/5-lat-pulldown-variations-for-an-impressive-physique--v2-3-700xh.jpg" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Dumbell shrugs",
                        Description = "Perform dumbbell shrugs by grabbing a pair of dumbbells and holding them by your sides with a neutral grip. Keep your arms straight as you lift your shoulders toward your ears. Pause for a moment before lowering your shoulders back to the starting position. Repeat this movement for the desired amount of time.",
                        MuscleGroupId = 2,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=8lP_eJvClSA&ab_channel=Bodybuilding.com"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.inspireusafoundation.org/wp-content/uploads/2021/11/dumbbell-shrug-benefits.jpg" },
                        new Image {Url = "https://hortonbarbell.com/wp-content/uploads/2022/07/DB-Shrugs.png" },
                        }
                    },
                    // 3 Bicep exercises
                    new Exercise()
                    {
                        Name = "Dumbbell Curl",
                        Description = " To do a biceps curl with a dumbbell, hold a dumbbell with your palm facing upward. Slowly curl the weight up by bending your elbow, keeping your elbow close to your body. Then slowly lower the weight to the starting position. You'll feel tension in the muscles in the front of your upper arm.",
                        MuscleGroupId = 3,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=sAq_ocpRh_I&ab_channel=ScottHermanFitness"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://image.myupchar.com/8840/original/Standing_Dumbbell_Curl_ke_fayde__karne_ka_sahi_tarika__prakar__galtiyan_aur_sujhav.jpg" },
                        new Image {Url = "https://s3assets.skimble.com/assets/2287282/image_iphone.jpg" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Barbell Curl",
                        Description = "A barbell curl is a variation of the biceps curl that uses a weighted barbell. Perform barbell curls by grabbing a barbell with a shoulder-width supinated grip (palms facing towards your body). Hinge your elbows, and lift the barbell toward your chest.",
                        MuscleGroupId = 3,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=kwG2ipFRgfo&ab_channel=Howcast"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://fitnessvolt.com/wp-content/uploads/2020/08/how-to-barbell-reverse-curl.jpg" },
                        new Image {Url = "https://cdn.media.amplience.net/i/thegymgroup/The_Gym_Group-Exercises-How_To_Do_A_Barbell_Bicep_Curl-Step_By_Step_3?fmt=auto&h=545&w=1440&sm=c&qlt=default&$qlt$&$poi$" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Hammer Curl",
                        Description = "Hammer curls are biceps curls performed with your hands facing each other. They're beneficial to add mass to your arms and can help focus more attention on the short head of the biceps. They may be easier to tolerate than the traditional biceps curl.",
                        MuscleGroupId = 3,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=TwD-YGVP4Bk&ab_channel=Howcast"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.fitstream.com/images/weight-training/exercises/hammer-curl.png" },
                        new Image {Url = "https://static.strengthlevel.com/images/illustrations/hammer-curl-1000x1000.jpg" },
                        }
                    },
                    // 3 Calf exercises
                    new Exercise()
                    {
                        Name = "Calf raises",
                        Description = "The calf raise, also known as the standing calf raise, is a bodyweight exercise that targets the muscle groups in your lower legs. Perform calf raises by standing tall with your feet hip-width apart. Lift your body by pushing into the fronts of your feet, activating your calf muscles as you stand on your tiptoes.",
                        MuscleGroupId = 4,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=gwLzBJYoWlI&ab_channel=LIVESTRONG.COM"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://geeksonfeet.com/img/workouts/calfraises_hu70808923bf27faf24ab2eb790fa98c30_40649_1200x0_resize_q100_h2_box.webp" },
                        new Image {Url = "https://www.ironmanmagazine.com/wp-content/uploads/MCP_5245-scaled.jpg" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Jump Rope",
                        Description = "Jumping rope is a form of exercise that involves swinging a rope around your body and jumping over it as it passes under your feet. It's a form of cardiovascular training since the constant movement elevates your heart rate. The basic concept of jumping rope is simple.",
                        MuscleGroupId = 4,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=ICusNoO6za4&ab_channel=JumpRopeDudes"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://cdn2.stylecraze.com/wp-content/uploads/2014/07/Is-Rope-Jumping-Good-For-Health-Benefits-And-Precautions.jpg" },
                        new Image {Url = "https://www.inspireusafoundation.org/wp-content/uploads/2021/08/jumping-rope-1024x445.png" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Farmer's Carry ",
                        Description = "The farmer's walk, also called the farmer's carry, is a strength and conditioning exercise in which you hold a heavy load in each hand while walking for a designated distance. This whole body exercise hits most of the major muscle groups while providing an excellent cardiovascular stimulus.",
                        MuscleGroupId = 4,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=Fkzk_RqlYig&ab_channel=BuffDudes"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.bodybuilding.com/fun/images/2015/3-perfect-farmers-carry-finishers-graphics-1-700xh.jpg" },
                        new Image {Url = "https://cdn-0.weighttraining.guide/wp-content/uploads/2021/04/Dumbbell-farmers-walk-2.png?ezimgfmt=ng%3Awebp%2Fngcb4" },
                        }
                    },
                    // 3 Chest exercises
                    new Exercise()
                    {
                        Name = "Bench Press",
                        Description = "The bench press is a compound exercise that targets the muscles of the upper body. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells. During a bench press, you lower the weight down to chest level and then press upwards while extending your arms.",
                        MuscleGroupId = 5,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=4Y2ZdHCOXok&ab_channel=JeremyEthier"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.inspireusafoundation.org/wp-content/uploads/2022/06/barbell-bench-press-benefits-1024x576.jpg" },
                        new Image {Url = "https://www.muscleandfitness.com/wp-content/uploads/2019/04/10-Exercises-Build-Muscle-Bench-Press.jpg?quality=86&strip=all" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Cable Chest Flys",
                        Description = "Set the cables so they're just above head height and attach single handles to both. Face away from the machine and, gripping both handles, step forward into a staggered stance. Squeeze the chest muscles and press your arms forward and down in an arc direction until the handles meet back in front of the chest.",
                        MuscleGroupId = 5,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=wDJozUD0bnQ&ab_channel=ColossusFitness"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://bod-blog-assets.prod.cd.beachbodyondemand.com/bod-blog/wp-content/uploads/2018/04/cable-chest-fly-sagi-kalev.jpg" },
                        new Image {Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSLmKZ-LYyKUpuQojj8B238QfQ_5v8tX65kxg&usqp=CAU" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Push ups",
                        Description = "Push-ups are an exercise in which a person, keeping a prone position, with the hands palms down under the shoulders, the balls of the feet on the ground, and the back straight, pushes the body up and lets it down by an alternate straightening and bending of the arms.",
                        MuscleGroupId = 5,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=IODxDxX7oi4&ab_channel=Calisthenicmovement"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.physio-pedia.com/images/2/26/Classic-push-up_push-up-variations.jpg" },
                        new Image {Url = "https://www.wikihow.com/images/thumb/9/96/Increase-the-Number-of-Pushups-You-Can-Do-Step-13-Version-3.jpg/aid403933-v4-1200px-Increase-the-Number-of-Pushups-You-Can-Do-Step-13-Version-3.jpg" },
                        }
                    },
                    // 3 Forearm exercises
                    new Exercise()
                    {
                        Name = "Dumbbell Wrist Flexion",
                        Description = "Don’t be deceived by how easy this move sounds — this simple motion helps target and strengthen your wrist flexors, which are crucial in building grip strength.",
                        MuscleGroupId = 6,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=il8ZE5eXIts&ab_channel=OrigymPersonalTrainerCourses"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.inspireusafoundation.org/wp-content/uploads/2021/11/dumbbell-reverse-wrist-curl-1024x487.png" },
                        new Image {Url = "https://1.bp.blogspot.com/-69v2rtzK350/WWjwC1acV3I/AAAAAAAABXw/fY_YdaQWbyQ6mmbxnU8KFxN33JbUPEUOwCLcBGAs/s1600/wrist-curl.jpg" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Dumbbell Reverse Curl",
                        Description = "Stand up with your back straight, shoulders back, and chest lifted. Grip a set of dumbbells with your palms facing down (pronated grip) and rest the weights on the front of your thighs. Exhale and bend your elbows to lift the weights toward your shoulders. Lift the weights until you feel a complete biceps contraction.",
                        MuscleGroupId = 6,
                        Video = new Video
                        {
                            Url = "https://youtu.be/i5h3myNHVFk"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://cdn.shopify.com/s/files/1/1497/9682/files/2_f2d1dab5-fca3-4f35-9425-0a1cc728993c.jpg?v=1653395042" },
                        new Image {Url = "https://cdn.shopify.com/s/files/1/1497/9682/articles/Main_Image_1793204a-02bb-485e-8ce8-25bd7eeff5cc.jpg?v=1670421534" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Pull-Up Bar Hang",
                        Description = "A pull-up is an upper-body strength exercise. The pull-up is a closed-chain movement where the body is suspended by the hands, gripping a bar or other implement at a distance typically wider than shoulder-width, and pulled up.",
                        MuscleGroupId = 6,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=lYHfRYUHdqE&ab_channel=BarRookie"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://assets.sweat.com/html_body_blocks/images/000/018/749/original/SWEAT_Pull_Up_HERO_encb0615824d58fd5b4e9589238a6e0342.jpg?1597200703" },
                        new Image {Url = "https://qph.cf2.quoracdn.net/main-qimg-a7d984f1d0a5bbd4c904d673d9be31ec-pjlq" },
                        }
                    },
                    // 3 Legs exercises
                    new Exercise()
                    {
                        Name = "Squats",
                        Description = "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes; conversely the hip and knee joints extend and the ankle joint plantarflexes when standing up.",
                        MuscleGroupId = 7,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=YaXPRqUwItQ&ab_channel=MindBodySoul"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.realsimple.com/thmb/8n1R3DyNvVKSAGn8Lzif7zRB8Jg=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/squat-infographic-d23c1dafcaef4c688ee7d6f828c8dd1b.png" },
                        new Image {Url = "https://assets.vogue.in/photos/5f645595705e820dfee8dfd2/1:1/pass/undefined" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Lunges",
                        Description = "It involves stepping forward, lowering your body toward the ground, and returning back to the starting position. It's the version most people will refer to when they say they're “doing lunges.” In the beginning of the exercise, your leg muscles have to control the impact of your foot's landing.",
                        MuscleGroupId = 7,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=QOVaHwm-Q6U&ab_channel=Bowflex"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://media1.popsugar-assets.com/files/thumbor/XBjqBbublGCisq8WJ589r9Ljlws/fit-in/2048xorig/filters:format_auto-!!-:strip_icc-!!-/2018/12/28/137/n/1922729/tmp_1KPWA3_4a8efb52e5e289b7_PS17_0001_GetFit_Fitness_Workout_0738.jpg" },
                        new Image {Url = "https://www.verywellfit.com/thmb/2M77NtV1A9m_tN9QupDJpGm_dgE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/About-8-2911936-Low-Lunge-Kneel-Hamstring-Stretch01-131-12eb2bbe1c5c462e80313c7de44edd2e.jpg" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Deadlifts",
                        Description = "Deadlift. The deadlift exercise is a relatively simple exercise to perform, a weight is lifted from a resting position on the floor to an upright position. The deadlift exercise utilizes multiple muscle groups to perform but has been used to strength the hips, thighs, and back musculature.",
                        MuscleGroupId = 7,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=r4MzxtBKyNE&ab_channel=Men%27sHealth"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://hips.hearstapps.com/hmg-prod/images/trap-bar-deadlift-1618411658.jpg" },
                        new Image {Url = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Barbell-Deadlift-1.png?ezimgfmt=ng%3Awebp%2Fngcb4" },
                        }
                    },
                    // 3 Shoulders exercises
                    new Exercise()
                    {
                        Name = "Dumbbell Overhead Press",
                        Description = "Stand upright and keep the back straight. Hold a dumbbell in each hand, at the shoulders, with an overhand grip.",
                        MuscleGroupId = 8,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=M2rwvNhTOu0&ab_channel=3v"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://static.strengthlevel.com/images/illustrations/dumbbell-shoulder-press-1000x1000.jpg" },
                        new Image {Url = "https://static.strengthlevel.com/images/illustrations/seated-dumbbell-shoulder-press-1000x1000.jpg" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Overhead press",
                        Description = "The overhead press, also known as the shoulder press or military press, is an upper-body weight training exercise in which the trainee presses a weight overhead while seated or standing. It is mainly used to develop the anterior deltoid muscles of the shoulder.",
                        MuscleGroupId = 8,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=0JfYxMRsUCQ&ab_channel=Bodybuilding.com"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://i.ytimg.com/vi/0JfYxMRsUCQ/maxresdefault.jpg" },
                        new Image {Url = "https://cdn.shopify.com/s/files/1/1283/2557/files/Shoulder_Press_Muscles_Worked_2048x2048.jpg?v=1657756668" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Push Press",
                        Description = "The push press is an overhead press variant that uses the legs to create power. To begin the lift, the legs bend to an athletic dip position, followed by a speedy extension of the body to drive the weight overhead. A successful completion of the lift ends with the bar overhead, with both the arms and legs straight.",
                        MuscleGroupId = 8,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=iaBVSJm78ko&ab_channel=CrossFit"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://cdn.mos.cms.futurecdn.net/jpHXHGv9zGvW2Ngu3eEnxL.jpg" },
                        new Image {Url = "https://www.muscleandfitness.com/wp-content/uploads/2018/04/1109-barbell-hang-clean.jpg?quality=86&strip=all" },
                        }
                    },
                    // 3 Tricep exercises
                    new Exercise()
                    {
                        Name = "Tricep Extensions",
                        Description = "Extend your arms straight overhead, bend them at the elbows, and lower the dumbbells behind your head. (If this is too difficult with a weight in each hand, just hold one weight between both hands.) Extend arms back straight overhead to the starting position and repeat.",
                        MuscleGroupId = 9,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=nRiJVZDpdL0&ab_channel=LIVESTRONG.COM"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.spotebi.com/wp-content/uploads/2014/10/dumbbell-triceps-extension-exercise-illustration.jpg" },
                        new Image {Url = "https://bod-blog-assets.prod.cd.beachbodyondemand.com/bod-blog/wp-content/uploads/2018/04/02113858/overhead-triceps-extension-600-demo.jpg" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Bench Dips",
                        Description = "Walk your feet out and extend your legs, lifting your bottom off the bench and holding there with extended arms. Hinging at the elbow, lower your body down as far as you can go, or until your arms form a 90-degree angle. Push up through your palms back to start.",
                        MuscleGroupId = 9,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=jdFzYGmvDyg&ab_channel=ATHLEAN-X%E2%84%A2"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://cdn.shopify.com/s/files/1/1876/4703/articles/shutterstock_1526664821_1000x.jpg?v=1644523346" },
                        new Image {Url = "https://www.burnthefatinnercircle.com/members/images/1093f.jpg?cb=20230213050608" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Skull Crushers",
                        Description = "A skull crusher, also known as a lying triceps extension, is an isolation exercise focused on your triceps muscles. Skull crushers are performed by lying on your back on a flat bench and lifting dumbbells from behind your head to full extension above you.",
                        MuscleGroupId = 9,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=d_KZxkY_0cM&ab_channel=ScottHermanFitness"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.inspireusafoundation.org/wp-content/uploads/2022/03/skull-crusher-alternatives.jpg" },
                        new Image {Url = "https://pump-app.s3.eu-west-2.amazonaws.com/exercise-assets/03511101-Dumbbell-Lying-Triceps-Extension_Upper-Arms_small.jpg" },
                        }
                    },
                    // 3 All body exercises
                    new Exercise()
                    {
                        Name = "Burpees",
                        Description = "A burpee is essentially a two-part exercise: a pushup followed by a leap in the air. Doing several burpees in a row can be tiring, but this versatile exercise may be worth the payoff, especially if you're looking for a way to build strength and endurance, while burning calories, and boosting your cardio fitness.",
                        MuscleGroupId = 10,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=qLBImHhCXSw&ab_channel=Well%2BGood"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://physicalculturestudy.com/wp-content/uploads/2017/02/31-e1406329504878.jpg" },
                        new Image {Url = "https://www.mensjournal.com/.image/t_share/MTk2MTM2Njg2NjY2NTg5MzI5/1380-burpee.jpg" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Stair climbing",
                        Description = "Stair climbing engages your body's largest muscle groups to repeatedly lift your body weight up, step after step. Thus using your muscles to carry your own weight is far higher to running as compared. Maximizes your cardio efforts: It also raises your heart rate immediately thus maximizing your cardio benefits.",
                        MuscleGroupId = 10,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=8pGwlHuVbBw&ab_channel=NEWS9Live"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://www.shape.com/thmb/sDotXFzB6ug9Ha8QBG0Coc6HF6k=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/stair-climber-AdobeStock_447239362-2000-f8df7c0f7146484ab0d02c543df8672f.jpg" },
                        new Image {Url = "https://www.eatthis.com/wp-content/uploads/sites/4/2023/01/woman-close-up-legs-stair-climber.jpg?quality=82&strip=1" },
                        }
                    },
                    new Exercise()
                    {
                        Name = "Cycling",
                        Description = "Cycling improves strength, balance and coordination. It may also help to prevent falls and fractures. Riding a bike is an ideal form of exercise if you have osteoarthritis, because it is a low-impact exercise that places little stress on joints.",
                        MuscleGroupId = 10,
                        Video = new Video
                        {
                            Url = "https://www.youtube.com/watch?v=ymuQtR_-Loc&ab_channel=GlobalCyclingNetwork"
                        },
                        AddedByUserId = AdminId,
                        CreatedOn = DateTime.UtcNow,
                        Images = new HashSet<Image>()
                        {
                        new Image {Url = "https://cdn.horizonfitness.rocks/catalog/product/7/-/7-0ic-main-13a_sm.jpg" },
                        new Image {Url = "https://callisto.ggsrv.com/imgsrv/FastFetch/UBER1/9781410379764_00169" },
                        }
                    });

                context.SaveChanges();
            }      
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            Task
                .Run(async () =>
                {
                    const string adminEmail = "admin@app.com";
                    const string adminPassword = "admin12app";

                    var user = new ApplicationUser
                    {
                        Id = AdminId,
                        Email = adminEmail,
                        UserName = adminEmail,
                        FirstName = "Admin",
                        LastName = "Admin"
                    };

                    await userManager.CreateAsync(user, adminPassword);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}