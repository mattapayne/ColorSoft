using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> DoNotSet<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression,
            params Expression<Func<TDestination, object>>[] destinationMembers)
        {
            if (destinationMembers != null)
            {
                expression = destinationMembers.Aggregate(expression,
                                                          (current, destinationMember) =>
                                                          current.ForMember(destinationMember, opts => opts.Ignore()));
            }

            return expression;
        }
    }
}