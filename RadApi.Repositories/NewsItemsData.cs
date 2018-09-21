using System;
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
                PublishDate = new DateTime(2008, 9, 22, 14, 30, 0)
                
            },
            new NewsItem
            {
                Id = 2,
                Title = "Gold Raiders",
                ImgSource = "http://dummyimage.com/231x208.jpg/ff4444/ffffff",
                ShortDescription = "Inj flexor musc/fasc/tend",
                LongDescription = "Other injury of flexor muscle, fascia and tendon of left little finger at wrist and hand level, subsequent encounter",
                PublishDate = new DateTime(2018, 8, 12, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 3,
                Title = "King of Kong, The",
                ImgSource ="http://dummyimage.com/188x174.png/cc0000/ffffff",
                ShortDescription = "Oth fx upr & low end l fibula",
                LongDescription = "Other fracture of upper and lower end of left fibula, subsequent encounter for closed fracture with delayed healing",
                PublishDate = new DateTime(2017, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 4,
                Title = "Young at Heart",
                ImgSource = "http://dummyimage.com/149x192.png/dddddd/000000",
                ShortDescription = "Matern care for damag to fts from",
                LongDescription = "Maternal care for (suspected) damage to fetus from viral disease in mother, fetus 1",
                PublishDate = new DateTime(2016, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 5,
                Title = "Backdraft",
                ImgSource ="http://dummyimage.com/188x174.png/cc0000/ffffff",
                ShortDescription = "Displ seg fx shaft of l femr",
                LongDescription = "Displaced segmental fracture of shaft of left femur, subsequent encounter for open fracture type IIIA, IIIB, or IIIC with nonunion",
                PublishDate = new DateTime(2015, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 6,
                Title = "French Film",
                ImgSource = "http://dummyimage.com/243x188.bmp/5fa2dd/ffffff",
                ShortDescription = "Rubella encephalitis",
                LongDescription = "Rubella encephalitisRubella encephalitisRubella encephalitisRubella encephalitisRubella encephalitisRubella encephalitis",
                PublishDate = new DateTime(2009, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 7,
                Title = "Mad Love",
                ImgSource ="http://dummyimage.com/188x174.png/cc0000/ffffff",
                ShortDescription = "Migraine, unsp, intractable",
                LongDescription = "Migraine, unspecified, intractable, without status migrainosusmigrainosusmigrainosus",
                PublishDate = new DateTime(2010, 1, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 8,
                Title = "Wave, The (Welle, Die)",
                ImgSource = "http://dummyimage.com/243x188.bmp/5fa2dd/ffffff",
                ShortDescription = "Breakdown (mechanical) of aortic",
                LongDescription = "Breakdown (mechanical) of aortic (bifurcation) graft (replacement), subsequent encounter subsequent encounter subsequent encounter",
                PublishDate = new DateTime(20011, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 9,
                Title = "Sheik, The",
                ImgSource = "http://dummyimage.com/217x134.png/5fa2dd/ffffff",
                ShortDescription = "Chorioamnionitis",
                LongDescription = "Chorioamnionitis, unspecified trimester, fetus 3trimester, fetus 3trimester, fetus 3trimester, fetus 3trimester, fetus 3",
                PublishDate = new DateTime(2012, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 10,
                Title = "The Butter Battle Book",
                ImgSource = "http://dummyimage.com/123x176.png/ff4444/ffffff",
                ShortDescription = "Steatocystoma multiplex",
                LongDescription = "Steatocystoma multiplexSteatocystoma multiplexSteatocystoma multiplexSteatocystoma multiplexSteatocystoma multiplex",
                PublishDate = new DateTime(2013, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 11,
                Title = "Foo Fighters: Back and Forth",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Isolated proteinuria with dense",
                LongDescription = "Isolated proteinuria with dense deposit disease deposit disease deposit disease deposit disease deposit disease",
                PublishDate = new DateTime(2008, 1, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 12,
                Title = "Cook the Thief His Wife & Her Lover, The",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Acquired absence of right upper limb below elbow",
                LongDescription = "Acquired absence of right upper limb below elbowupper limb below elbowupper limb below elbowupper limb below elbowupper limb below elbow",
                PublishDate = new DateTime(2008, 5, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 13,
                Title = "Glimpse Inside the Mind of Charles Swan III, A",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Intentional self-harm by drown",
                LongDescription = "Intentional self-harm by drowning and submersion in natural water, subsequent encounter",
                PublishDate = new DateTime(2002, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 14,
                Title = "Bounty Hunters (Bail Enforcers)",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Mech compl of surgically created",
                LongDescription = "Other mechanical complication of surgically created arteriovenous fistula, initial encounter",
                PublishDate = new DateTime(2001, 9, 22, 14, 30, 0)

            },
            new NewsItem
            {
                Id = 15,
                Title = "Little Mermaid: Ariel's Beginning, The",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Ototoxic hearing loss, bilateral",
                LongDescription = "Ototoxic hearing loss, bilateralOtotoxic hearing loss, bilateralOtotoxic hearing loss, bilateralOtotoxic hearing loss, bilateral",
                PublishDate = new DateTime(2014, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 16,
                Title = "Dinoshark",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Toxic effect of cyanides",
                LongDescription = "Toxic effect of cyanides, accidental (unintentional), subsequent encounter",
                PublishDate = new DateTime(2011, 2, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 17,
                Title = "Bungee Jumping of Their Own (Beonjijeompeureul hada)",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "External constriction",
                LongDescription = "External constriction, unspecified thigh, subsequent encounter",
                PublishDate = new DateTime(1999, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 18,
                Title = "Doctor Takes a Wife, The",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Naegleriasis",
                LongDescription = "NaegleriasisNaegleriasis Naegleriasis Naegleriasis Naegleriasis Naegleriasis Naegleriasis Naegleriasis Naegleriasis",
                PublishDate = new DateTime(1980, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 19,
                Title = "Thousand Words, A",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Bedroom of single-family",
                LongDescription = "Bedroom of single-family (private) house as the place of occurrence of the external cause",
                PublishDate = new DateTime(1985, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 20,
                Title = "Happy Go Lovely",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Lattice degeneration of retina",
                LongDescription = "Lattice degeneration of retina, right eyeright eyeright eyeright eyeright eye",
                PublishDate = new DateTime(1979, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 21,
                Title = "Planet of the Vampires (Terrore nello spazio)",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Pedl cyc driver injured in collision",
                LongDescription = "Pedal cycle driver injured in collision with unspecified motor vehicles in nontraffic accident, subsequent encounter",
                PublishDate = new DateTime(1980, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 22,
                Title = "Sleepover",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Balloon explosion",
                LongDescription = "Balloon explosion injuring occupant, sequelaequelaequelaequelaequelaequelaequelaequela",
                PublishDate = new DateTime(1945, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 23,
                Title = "Time Tracers",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "External constriction, right foot",
                LongDescription = "External constriction, right foot, initial encounterm External constriction, right foot, initial encounter",
                PublishDate = new DateTime(1950, 9, 22, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 24,
                Title = "Little Buddha",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Driver of military vehicle",
                LongDescription = "Driver of military vehicle injured in traffic accident, initial encounter",
                PublishDate = new DateTime(2001, 7, 21, 14, 30, 0)
            },
            new NewsItem
            {
                Id = 25,
                Title = "Ice Age: A Mammoth Christmas",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "Inj unsp musc/fasc/tend",
                LongDescription = "Other injury of unspecified muscles, fascia and tendons at forearm level, left arm, initial encounter",
                PublishDate = new DateTime(1994, 9, 22, 14, 30, 0)
            },
             new NewsItem
            {
                Id = 26,
                Title = "Ice Age: A Mammoth Version 2",
                ImgSource = "http://dummyimage.com/154x136.jpg/5fa2dd/ffffff",
                ShortDescription = "super duper short desc",
                LongDescription = "Super duper long desc, Super duper long desc, Super duper long desc, Super duper long desc, ",
                PublishDate = new DateTime(2015, 9, 22, 14, 30, 0)
            }
        };
        public static List<NewsItem> Models { get => _models; set => _models = value; }
    }
}