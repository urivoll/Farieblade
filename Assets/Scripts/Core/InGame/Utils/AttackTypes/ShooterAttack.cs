using Events;
using InGame.Utils;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.InGame.Utils
{
    public class ShooterAttack : EventDispatcher
    {
        [Inject] private Factory _factory;

        private List<Projectile> listProj = new();

        public void Open()
        {

        }

        public void Attack(Vector2 from, Vector2 to, GameObject projectile)
        {
            Projectile proj = _factory.CreateProjectile(from, to, projectile);
            listProj.Add(proj);
            int indexProj = listProj.IndexOf(proj);
            proj.Open(to, indexProj);
            proj.AddListener("Done", Done);
        }

        private void Done(EventArgs evt)
        {
            var index = (int)evt.args[0];
            listProj[index].Close();
            listProj.RemoveAt(index);
            DispatchEvent("Done", index);
        }
    }
}