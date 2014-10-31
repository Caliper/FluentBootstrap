﻿using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IBlockquoteCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class BlockquoteWrapper<TModel> : TagWrapper<TModel>
    {
    }
    internal interface IBlockquote : ITag
    {
    }

    public class Blockquote<TModel> : Tag<TModel, Blockquote<TModel>, BlockquoteWrapper<TModel>>, IBlockquote
    {
        internal Blockquote(IComponentCreator<TModel> creator)
            : base(creator, "blockquote")
        {
        }

        internal string Quote { get; set; }
        internal string Footer { get; set; }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if (!string.IsNullOrWhiteSpace(Quote))
            {
                new Element<TModel>(Helper, "p").SetText(Quote).StartAndFinish(writer);
            }

            if (!string.IsNullOrWhiteSpace(Footer))
            {
                new Element<TModel>(Helper, "footer").SetText(Footer).StartAndFinish(writer);
            }
        }
    }
}
