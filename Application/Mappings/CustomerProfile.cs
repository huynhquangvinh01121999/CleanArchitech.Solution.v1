using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class CustomerProfile
    {
        // convert entity -> dto
        public static CustomerDto MappingCustomerDto(this Customers customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Contact = customer.Contact,
                Email = customer.Email,
                DateOfBirth = customer.DateOfBirth,
                Created = customer.Created
            };
        }

        // convert entity -> dto
        public static Customers MappingCustomerDto(this CustomerDto customerDto)
        {
            return new Customers
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Contact = customerDto.Contact,
                Email = customerDto.Email,
                DateOfBirth = customerDto.DateOfBirth
            };
        }
    }
}
