﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using RedSwanStore.Data.Models;

namespace RedSwanStore.Utils
{
    public static class Extensions
    {
        public static XmlNode GetNode(this IEnumerable<XmlNode> lst, string nodeName)
        {
            return lst.First(n => n.Name == nodeName);
        }
        
        public static string GetNodeInnerText(this IEnumerable<XmlNode> lst, string nodeName)
        {
            return lst.GetNode(nodeName).InnerText;
        }

        public static string GetNodeInnerXml(this IEnumerable<XmlNode> lst, string nodeName)
        {
            return lst.GetNode(nodeName).InnerXml;
        }

        
        /// <summary>
        /// Check whether filter of this game match the specified filter.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="matchFilter">The filter to check.</param>
        /// <returns>True if this game has the same filter as the specified one.</returns>
        public static bool IsMatchFilter(this Game game, GameFilter matchFilter)
        {
            if (game is null)
                throw new ArgumentNullException(nameof(game));
            
            if (matchFilter is null)
                return true;
            
            
            var gameFilter = game.GameFilter;
            
            foreach (Feature feature in matchFilter.Features)
            {
                if (!gameFilter.Features.Exists(gf => gf.Name == feature.Name))
                    return false;
            }
            
            foreach (Genre genre in matchFilter.Genres)
            {
                if (!gameFilter.Genres.Exists(gg => gg.Name == genre.Name))
                    return false;
            }

            return true;
        }
        

        /// <summary>
        /// Check whether this game's price is in specified price category.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="category">The price category to check.</param>
        /// <returns>True if this game's price is in specified price category.</returns>
        public static bool IsMatchPriceCategory(this Game game, PriceCategory category)
        {
            if (game is null)
                throw new ArgumentNullException(nameof(game));
            
            if (category is null)
                return true;
            
            var gamePrice = game.GameInfo.Price * (decimal)(1 - game.GameInfo.Discount);

            return gamePrice >= category.MinPrice && gamePrice <= category.MaxPrice;
        }

    }
}