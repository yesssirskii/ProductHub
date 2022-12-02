using AutoMapper;
using ProductsAPI.Repositories;
using ProductsData.Entities;
using ProductsData.Models;

namespace ProductsAPI.Services
{
  public class ProductService : IProductService
  {
    private readonly IMapper _mapper;
    private readonly ProductDbContext _context;
    private readonly IProductRepository _productRepository;

    public ProductService(IMapper mapper, ProductDbContext context, IProductRepository productRepository)
    {
      _context = context;
      _mapper = mapper;
      _productRepository = productRepository;
    }

    // Methods containing HTTP method (GET, POST, PUT, DELETE) logic:
    public IEnumerable<GetProductsDTO> GetProducts()
    {
      return _mapper.Map<GetProductsDTO[]>(_productRepository.GetProducts());
    }

    public IEnumerable<GetProductTypesDTO> GetProductTypes()
    {
      return _mapper.Map<GetProductTypesDTO[]>(_productRepository.GetProductTypes());
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

