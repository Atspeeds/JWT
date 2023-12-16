using System;

namespace FrameWorkUni.FW.Domain
{
    public class EntityBase<TKey>
    {
        public EntityBase()
        {
            CreateionDate= DateTime.Now;
        }

        public TKey Key_Id { get; set; }
        public DateTime CreateionDate { get; set; }


    }
}
