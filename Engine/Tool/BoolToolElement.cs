﻿using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altseed2
{
    /// <summary>
    /// <see cref="bool"/>向けチェックボックス
    /// </summary>
    public class BoolToolElement : ToolElement
    {
        /// <summary>
        /// インスタンスを作成します。
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="source">バインディング対象オブジェクト</param>
        /// <param name="propertyName">バインディング対象プロパティ名</param>
        public BoolToolElement(string name, object source, string propertyName) : base(name, source, propertyName)
        {
            if (!typeof(bool).IsAssignableFrom(PropertyInfo?.PropertyType))
            {
                throw new ArgumentException("参照先がbool型ではありません");
            }
        }

        /// <inheritdoc/>
        public override void Update()
        {
            base.Update();

            if (Source == null || PropertyInfo == null) return;

            bool flag = (bool)PropertyInfo.GetValue(Source);
            if (Engine.Tool.CheckBox(Name, ref flag))
            {
                PropertyInfo.SetValue(Source, flag);
            }
        }

        /// <summary>
        /// <see cref="ToolElementManager.ObjectMapping"/>から<see cref="BoolToolElement"/>を作成します。
        /// </summary>
        /// <param name="source">バインディング対象</param>
        /// <param name="objectMapping"></param>
        /// <returns></returns>
        public static BoolToolElement Create(object source, ToolElementManager.ObjectMapping objectMapping)
        {
            return new BoolToolElement(objectMapping.Name, source, objectMapping.PropertyName);
        }
    }
}