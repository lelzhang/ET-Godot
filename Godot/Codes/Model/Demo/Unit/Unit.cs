using System;
using Godot;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    public class Unit: Entity, IAwake<int>
    {
        public int ConfigId; //配置表id

        [BsonIgnore]
        public UnitConfig Config => UnitConfigCategory.Instance.Get(this.ConfigId);

        private Vector3 position = new Vector3(); //坐标

        public Vector3 Position
        {
            get => this.position;
            set
            {
                EventType.ChangePosition.Instance.OldPos = this.position;
                this.position = value;

                EventType.ChangePosition.Instance.Unit = this;
                Game.EventSystem.PublishClass(EventType.ChangePosition.Instance);
            }
        }

        [BsonIgnore]
        public Vector3 Forward
        {
            get => this.Rotation * Vector3.Forward;
            set => this.Rotation = new Quaternion(value, Vector3.Up);
        }

        private Quaternion rotation = new Quaternion();
        public Quaternion Rotation
        {
            get => this.rotation;
            set
            {
                this.rotation= value;
                EventType.ChangeRotation.Instance.Unit = this;
                Game.EventSystem.PublishClass(EventType.ChangeRotation.Instance);
            }
        }
    }
}