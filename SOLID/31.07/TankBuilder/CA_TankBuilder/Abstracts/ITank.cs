using CA_TankBuilder.Models;

namespace CA_TankBuilder.Abstract
{
    internal interface ITank
    {
         void BuildTurret();
            void BuildHull();
            void BuildEngine();
            void BuildGun();
        Tank GetTank();
    }
}
