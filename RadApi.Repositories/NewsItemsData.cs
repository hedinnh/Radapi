using System.Collections.Generic;
using RadApi.Models.Entities;

namespace RadApi.Repositories
{
    public class NewsItemsData
    {
        private static List<NewsItem> _models = new List<NewsItem>
        {
            new NewsItem
            {
                Id = 1,
                Title = "Gurren Lagann: Childhood's End (Gekijô ban Tengen toppa guren ragan: Guren hen)",
                ImgSource = "http://dummyimage.com/149x192.png/dddddd/000000",
                ShortDescription = "Driver off-road veh injured",
                LongDescription = "Driver of special all-terrain or other off-road motor vehicle injured in traffic accident",
                PublishDate = "2016/06/05, 06:54:05"
            },
            new NewsItem
            {
                Id = 2,
                Title = "Gold Raiders",
                ImgSource = "http://dummyimage.com/231x208.jpg/ff4444/ffffff",
                ShortDescription = "Inj flexor musc/fasc/tend",
                LongDescription = "Other injury of flexor muscle, fascia and tendon of left little finger at wrist and hand level, subsequent encounter",
                PublishDate = "2015/02/01, 06:52:05"
            },
            new NewsItem
            {
                Id = 3,
                Title = "King of Kong, The",
                ImgSource ="http://dummyimage.com/188x174.png/cc0000/ffffff",
                ShortDescription = "Oth fx upr & low end l fibula",
                LongDescription = "Other fracture of upper and lower end of left fibula, subsequent encounter for closed fracture with delayed healing",
                PublishDate = "2017/09/17, 18:44:03"
            },
            new NewsItem
            {
                Id = 4,
                Title = "Young at Heart",
                ImgSource = "http://dummyimage.com/149x192.png/dddddd/000000",
                ShortDescription = "Matern care for damag to fts from",
                LongDescription = "Maternal care for (suspected) damage to fetus from viral disease in mother, fetus 1",
                PublishDate = "2017/05/09, 22:43:46"
            },
            new NewsItem
            {
                Id = 5,
                Title = "Backdraft",
                ImgSource ="http://dummyimage.com/188x174.png/cc0000/ffffff",
                ShortDescription = "Displ seg fx shaft of l femr",
                LongDescription = "Displaced segmental fracture of shaft of left femur, subsequent encounter for open fracture type IIIA, IIIB, or IIIC with nonunion",
                PublishDate = "2014/10/11, 18:42:28"
            },
            new NewsItem
            {
                Id = 6,
                Title = "French Film",
                ImgSource = "http://dummyimage.com/243x188.bmp/5fa2dd/ffffff",
                ShortDescription = "Rubella encephalitis",
                LongDescription = "Rubella encephalitisRubella encephalitisRubella encephalitisRubella encephalitisRubella encephalitisRubella encephalitis",
                PublishDate = "2016/01/21, 03:19:44"
            },
            new NewsItem
            {
                Id = 7,
                Title = "Mad Love",
                ImgSource ="http://dummyimage.com/188x174.png/cc0000/ffffff",
                ShortDescription = "Migraine, unsp, intractable",
                LongDescription = "Migraine, unspecified, intractable, without status migrainosusmigrainosusmigrainosus",
                PublishDate = "2017/06/17, 18:21:25"
            },
            new NewsItem
            {
                Id = 8,
                Title = "Wave, The (Welle, Die)",
                ImgSource = "http://dummyimage.com/243x188.bmp/5fa2dd/ffffff",
                ShortDescription = "Breakdown (mechanical) of aortic",
                LongDescription = "Breakdown (mechanical) of aortic (bifurcation) graft (replacement), subsequent encounter subsequent encounter subsequent encounter",
                PublishDate = "2014/08/19, 15:44:05"
            },
            new NewsItem
            {
                Id = 9,
                Title = "Sheik, The",
                ImgSource = "http://dummyimage.com/217x134.png/5fa2dd/ffffff",
                ShortDescription = "Chorioamnionitis",
                LongDescription = "Chorioamnionitis, unspecified trimester, fetus 3trimester, fetus 3trimester, fetus 3trimester, fetus 3trimester, fetus 3",
                PublishDate = "2015/08/23, 11:36:55"
            },
            new NewsItem
            {
                Id = 10,
                Title = "The Butter Battle Book",
                ImgSource = "http://dummyimage.com/123x176.png/ff4444/ffffff",
                ShortDescription = "Steatocystoma multiplex",
                LongDescription = "Steatocystoma multiplexSteatocystoma multiplexSteatocystoma multiplexSteatocystoma multiplexSteatocystoma multiplex",
                PublishDate = "2016/08/14, 11:11:29"
            },
            new NewsItem
            {
                Id = 11,
                Title = "Foo Fighters: Back and Forth",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Isolated proteinuria with dense",
                LongDescription = "Isolated proteinuria with dense deposit disease deposit disease deposit disease deposit disease deposit disease",
                PublishDate = "2014/12/08, 08:42:15"
            },
            new NewsItem
            {
                Id = 12,
                Title = "Cook the Thief His Wife & Her Lover, The",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Acquired absence of right upper limb below elbow",
                LongDescription = "Acquired absence of right upper limb below elbowupper limb below elbowupper limb below elbowupper limb below elbowupper limb below elbow",
                PublishDate = "2016/06/13, 12:38:42"
            },
            new NewsItem
            {
                Id = 13,
                Title = "Glimpse Inside the Mind of Charles Swan III, A",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Intentional self-harm by drown",
                LongDescription = "Intentional self-harm by drowning and submersion in natural water, subsequent encounter",
                PublishDate = "2015/11/25, 16:42:09"
            },
            new NewsItem
            {
                Id = 14,
                Title = "Bounty Hunters (Bail Enforcers)",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Mech compl of surgically created",
                LongDescription = "Other mechanical complication of surgically created arteriovenous fistula, initial encounter",
                PublishDate = "2015/11/06, 22:42:12"

            },
            new NewsItem
            {
                Id = 15,
                Title = "Little Mermaid: Ariel's Beginning, The",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Ototoxic hearing loss, bilateral",
                LongDescription = "Ototoxic hearing loss, bilateralOtotoxic hearing loss, bilateralOtotoxic hearing loss, bilateralOtotoxic hearing loss, bilateral",
                PublishDate = "2015/10/16, 06:50:07"
            },
            new NewsItem
            {
                Id = 16,
                Title = "Dinoshark",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Toxic effect of cyanides",
                LongDescription = "Toxic effect of cyanides, accidental (unintentional), subsequent encounter",
                PublishDate = "2017/04/10, 09:06:28"
            },
            new NewsItem
            {
                Id = 17,
                Title = "Bungee Jumping of Their Own (Beonjijeompeureul hada)",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "External constriction",
                LongDescription = "External constriction, unspecified thigh, subsequent encounter",
                PublishDate = "2017/05/19, 08:55:14"
            },
            new NewsItem
            {
                Id = 18,
                Title = "Doctor Takes a Wife, The",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Naegleriasis",
                LongDescription = "NaegleriasisNaegleriasis Naegleriasis Naegleriasis Naegleriasis Naegleriasis Naegleriasis Naegleriasis Naegleriasis",
                PublishDate = "2016/10/23, 15:57:27"
            },
            new NewsItem
            {
                Id = 19,
                Title = "Thousand Words, A",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Bedroom of single-family",
                LongDescription = "Bedroom of single-family (private) house as the place of occurrence of the external cause",
                PublishDate = "2017/07/15, 05:54:36"
            },
            new NewsItem
            {
                Id = 20,
                Title = "Happy Go Lovely",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Lattice degeneration of retina",
                LongDescription = "Lattice degeneration of retina, right eyeright eyeright eyeright eyeright eye",
                PublishDate = "2016/01/13, 04:38:08"
            },
            new NewsItem
            {
                Id = 21,
                Title = "Planet of the Vampires (Terrore nello spazio)",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Pedl cyc driver injured in collision",
                LongDescription = "Pedal cycle driver injured in collision with unspecified motor vehicles in nontraffic accident, subsequent encounter",
                PublishDate = "2015/12/26, 06:43:27"
            },
            new NewsItem
            {
                Id = 22,
                Title = "Sleepover",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Balloon explosion",
                LongDescription = "Balloon explosion injuring occupant, sequelaequelaequelaequelaequelaequelaequelaequela",
                PublishDate = "2015/03/02, 05:01:20"
            },
            new NewsItem
            {
                Id = 23,
                Title = "Time Tracers",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "External constriction, right foot",
                LongDescription = "External constriction, right foot, initial encounterm External constriction, right foot, initial encounter",
                PublishDate = "2015/04/21, 06:49:32"
            },
            new NewsItem
            {
                Id = 24,
                Title = "Little Buddha",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Driver of military vehicle",
                LongDescription = "Driver of military vehicle injured in traffic accident, initial encounter",
                PublishDate = "2015/02/12, 03:54:23"
            },
            new NewsItem
            {
                Id = 25,
                Title = "Ice Age: A Mammoth Christmas",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Inj unsp musc/fasc/tend",
                LongDescription = "Other injury of unspecified muscles, fascia and tendons at forearm level, left arm, initial encounter",
                PublishDate = "2016/12/27, 09:12:04"
            }
        };
        public static List<NewsItem> Models { get => _models; set => _models = value; }
    }
}