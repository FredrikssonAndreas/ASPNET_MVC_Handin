using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;


namespace Infrastructure.Services;

public class AddressService(AddressRepository addressRepository)
{
	private readonly AddressRepository _addressRepository = addressRepository;



}