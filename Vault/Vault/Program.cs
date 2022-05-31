using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Vault
{
    [ApiVersion(2, 1)]
    public class VaultPlugin : TerrariaPlugin
    {
        public override string Author => "Ozz5581";

        public override string Description => "Summon the Void Vault";

        public override string Name => "Vault";

        public override Version Version => new Version(1, 0, 0, 0);

        public VaultPlugin(Main game) : base(game)
        {

        }

        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command("vault.use", Vault, "vault", "v")
            {
                AllowServer = false,
                HelpText = "Summons the Void Vault."
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Deregister hooks here
            }
            base.Dispose(disposing);
        }

        private void Vault(CommandArgs args)
        {
            int type = ProjectileID.VoidLens;
            int p = Projectile.NewProjectile(Projectile.GetNoneSource(), args.Player.TPlayer.position.X, args.Player.TPlayer.position.Y - 0f, 0f, -0f, type, 0, 0);
            args.Player.SendData(PacketTypes.CreateCombatTextExtended, "Summoned the Vault!", (int)Color.Magenta.PackedValue, args.Player.X, args.Player.Y);
        }
    }
}