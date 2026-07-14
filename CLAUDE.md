# MaPagePerso

Stack : .NET 9, ASP.NET Core MVC (Razor) + EF Core (SQLite/SqlServer) +
Identity. Site perso de Florian (www.florianrampin.fr).

## Vault partagé

Le suivi de tâches et les décisions techniques de ce projet sont
centralisés dans l'orchestrateur `E:\Nowtilus` :

- Le suivi de **tâches** se fait dans **YouTrack** (`noovio.youtrack.cloud`,
  serveur MCP niveau utilisateur), projet `MPP` — pas dans `vault/tasks/`
  (déprécié).
- En début de session, lire `../../Nowtilus/vault/progress.md` (statut
  global du projet) pour récupérer le contexte.
- Si une décision technique structurante est prise, créer une entrée dans
  `../../Nowtilus/vault/decisions/` à partir de `ADR-template.md`.
- Si le statut global du projet change, mettre à jour la ligne
  correspondante dans `../../Nowtilus/vault/progress.md`.
- Ne jamais commiter/pousser de secret (connection strings, clés
  ReCaptcha/MailKit) — utiliser `dotnet user-secrets`.

## Contexte

<!-- À compléter : objectif du projet, état actuel, contraintes connues -->

## Commandes utiles

<!-- À compléter : build, test, lint, run -->
