using System;
using System.Collections.Generic;
using MaPagePerso.net.Models;

namespace MaPagePerso.net.Services
{
    public class ProjectService
    {
        public List<Project> GetAllProjects()
        {
            var p1 = new Project()
            {
                Id = 1,
                CreatedAt = new DateTime(2016, 1, 1),
                Title = "OutilFormation",
                Description = "Un outil complet et simplifié pour les actions du support technique.",
                Language = "C#/WF",
                Image = "ans2.png",
                Url = ""
            };
            var p2 = new Project()
            {
                Id = 2,
                CreatedAt = new DateTime(2017, 1, 1),
                Title = "SpiderLink",
                Description = "Un gestionnaire de lien pour les échanges entre le support technique et le service développement dont l'objectif est de communiquer sur les URL de téléchargement des mises à jour de logiciel.",
                Language = "C#/WF",
                Image = "ans1.png",
                Url = ""
            };
            var p3 = new Project()
            {
                Id = 3,
                CreatedAt = new DateTime(2018, 1, 1),
                Title = "EasyBacApi",
                Description = "Une api pour le suivi de mon aquarium. Gestion du cycle de l'eau, température etc... Cet outil est branché à l'application NOWTILUS",
                Language = "SYMFONY/PHP",
                Image = "easybacapi.png",
                Url = ""
            };
            var p4 = new Project()
            {
                Id = 4,
                CreatedAt = new DateTime(2018, 1, 1),
                Title = "Nowtilus",
                Description = "C'est mon app personnelle. On y retrouve un lecteur de flux RSS, un suivi de mon api EasyBac et d'autres fonctionalitées personnelles.",
                Language = "SYMFONY/PHP",
                Image = "nowtilus.png",
                Url = ""
            };
            var p5 = new Project()
            {
                Id = 5,
                CreatedAt = new DateTime(2018, 1, 1),
                Title = "Application de gestion",
                Description = "Application créée pour la société GENTEL qui permet un suivi de télégestion entre la société et les clients.",
                Language = "SYMFONY/PHP",
                Image = "tg.png",
                Url = ""
            };
            var p6 = new Project()
            {
                Id = 6,
                CreatedAt = new DateTime(2019, 1, 1),
                Title = "Port la montagne",
                Description = "Site de l'association d'escalade Port la montagne ",
                Language = "SYMFONY/PHP",
                Image = "portlamontagne.png",
                Url = ""
            };
            var p7 = new Project()
            {
                Id = 7,
                CreatedAt = new DateTime(2020, 1, 1),
                Title = "Ma page perso 2.0",
                Description = "Ma page perso 2.0",
                Language = "ASPNET/C#",
                Image = "mapageperso.png",
                Url = ""
            };
            var p8 = new Project()
            {
                Id = 8,
                CreatedAt = new DateTime(2021, 1, 1),
                Title = "Distillerie GTARP",
                Description = "Une application de gestion d'entreprise pour du rôle play sur GTA5",
                Language = "ASPNET/C#",
                Image = "DistillerieManzibar.png",
                Url = ""
            };
            var p9 = new Project()
            {
                Id = 9,
                CreatedAt = new DateTime(2022, 1, 1),
                Title = "The Last Hope",
                Description = "Un serveur de rôle play sur GTA5 avec des scripts complets maison",
                Language = "LUA",
                Image = "thelasthope.png",
                Url = ""
            };
            var p10 = new Project()
            {
                Id = 10,
                CreatedAt = new DateTime(2022, 6, 1),
                Title = "TheLastHope CommunityMeeting",
                Description = "application liée au projet TheLastHope pour les réunions mensuelles",
                Language = "ASPNET/C#",
                Image = "reunion.png",
                Url = ""
            };
            var p11 = new Project()
            {
                Id = 11,
                CreatedAt = new DateTime(2022, 8, 1),
                Title = "CI/CD Github Actions",
                Description = "Déploiement automatisé de mes applications via un processus CI/CD avec Github Actions.",
                Language = "LUA",
                Image = "ci_cd_workflow.png",
                Url = ""
            };
            var p12 = new Project()
            {
                Id = 12,
                CreatedAt = new DateTime(2022, 9, 1),
                Title = "The Last Bot",
                Description = "Un bot discord capable d'identifier les utilisateurs qui lancent un live et permet de notifier les utilisateurs du serveur dans un canal spécifique.",
                Language = "NETCORE/C#",
                Image = "thelastbot.png",
                Url = ""
            };

            var p13 = new Project()
            {
                Id = 13,
                CreatedAt = new DateTime(2022, 10, 1),
                Title = ">Ma page perso 3.0",
                Description = "Refonte complète du site que vous visitez actuellement.",
                Language = "ASPNET/C#",
                Image = "siteperso_refonte.png",
                Url = ""
            };

            var projects = new List<Project>
            {
                p1,
                p2,
                p3,
                p4,
                p5,
                p6,
                p7,
                p8,
                p9,
                p10,
                p11,
                p12,
                p13
            };

            return projects;
        }
    }
}
