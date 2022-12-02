using System;
using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Repositories;
using ProductsData.Entities;
using Microsoft.AspNetCore.Http;
using ProductsData.Models;

namespace ProductsAPI.Services
{
  public class ProductService : IProductService
  {
    // Injecting the ProductDTO context class and AutoMapper into the product service:
    private readonly ProductDbContext _context;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(ProductDbContext context, IMapper mapper, IProductRepository productRepository)
    {
      _context = context;
      _mapper = mapper;
      _productRepository = productRepository;
    }

    /*public async Task<ActionResult<List<Product>>> GetProducts()
    {
      return await _context.Products.ToListAsync();
    }
    public IEnumerable<Product> CreateProduct(ProductDTO productDto)
    {
      _context.Products.Add(_mapper.Map<Product>(productDto));
      _context.SaveChanges();

      return _productRepository.GetProducts();
    }
    public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product product)
    {

      var dbProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

      dbProduct.Name = product.Name;
      dbProduct.Price = product.Price;
      dbProduct.Country = product.Country;
      dbProduct.ProductType = product.ProductType;

      await _context.SaveChangesAsync();

      return await _context.Products.ToListAsync();
    }

    public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
    {
      _context.Products.Remove(_context.Products.FirstOrDefault(a => a.ProductId == id));
      await _context.SaveChangesAsync();

      return await _context.Products.ToListAsync();
    }*/

   
    public IEnumerable<GetProductsDTO> GetProducts()
    {
      return _mapper.Map<GetProductsDTO[]>(_productRepository.GetProducts());
    }
    public IEnumerable<Product> CreateProduct(CreateProductDTO createProductDto)
    {
      _context.Products.Add(_mapper.Map<Product>(createProductDto));
      _context.SaveChanges();

      return _productRepository.GetProducts();
    }
    public IEnumerable<Product> UpdateProduct(int id, UpdateProductDTO updateProductDto)
    {
      var dbProduct = _context.Products.FirstOrDefault(x => x.ProductId == id);

      dbProduct.Name = updateProductDto.Name;
      dbProduct.Price = updateProductDto.Price;
      dbProduct.Country = updateProductDto.Country;

      _context.Products.Update(_mapper.Map<Product>(dbProduct));
      _context.SaveChanges();

      return _productRepository.GetProducts();
    }
    public IEnumerable<DeleteProductDTO> DeleteProduct (int id)
    {
      return _mapper.Map<DeleteProductDTO[]>(_productRepository.DeleteProduct(id));
    }
  }
}

