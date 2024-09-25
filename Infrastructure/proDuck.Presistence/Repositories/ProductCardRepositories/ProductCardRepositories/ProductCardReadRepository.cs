﻿using proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface;
using proDuck.Application.Repositories.ProductImageFileInterface;
using proDuck.Domain.Entities;
using proDuck.Domain.Entities.ProductCard;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Presistence.Repositories.ProductCardRepositories.ProductCardRepositories
{
    public class ProductCardReadRepository : ReadRepository<TBL_ProductCard>, IProductCardReadRepository
    {
        public ProductCardReadRepository(proDuckDbContext dbContext) : base(dbContext)
        { 
        }
    }
}
