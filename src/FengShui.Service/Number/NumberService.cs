using AutoMapper;
using Coffee.Libs.DataAccess.UnitOfWork;
using Coffee.Libs.Service;
using FengShui.Service.Dtos;
using Snp.TosFix.DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FengShui.Service
{
    public class NumberService : BaseService, INumberService
    {
        private readonly IPhoneRepository _phoneRepository;

        public NumberService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPhoneRepository phoneRepository) : base(unitOfWork, mapper)
        {
            _phoneRepository = phoneRepository;
        }

        public List<PhoneDto> GetFengShui(FengShuiNumberConfiguration config)
        {
            //var records = _phoneRepository.FindBy(x => !x.IsDeleted).ToList();

            var records = new List<DataAccess.Entities.Phone>()
            {
                new DataAccess.Entities.Phone
                {
                    Id = 1,
                    Number = "0868667670"
                }
            };

            List<PhoneDto> fengShuis = _mapper.Map<List<PhoneDto>>(records);
            List<string> removePhone = new List<string>();

            foreach (var item in fengShuis)
            {
                //Invalid feng shui numbers
                if (InvalidGoodFengShuiNumbers(item.Number, config))
                {
                    removePhone.Add(item.Number);
                    continue;
                }

                //Good feng shui numbers
                if (!IsGoodFengShuiNumbers(item.Number, config))
                {
                    removePhone.Add(item.Number);
                    continue;
                }
            }

            fengShuis.RemoveAll(x => removePhone.Contains(x.Number));

            return fengShuis;
        }

        private bool InvalidGoodFengShuiNumbers(string number, FengShuiNumberConfiguration config)
        {
            //Mobile phone format Apply for 3 mobile network provider
            if (string.IsNullOrWhiteSpace(number) || number.Length != config.PhoneLength)
            {
                return true;
            }

            //Apply for 3 mobile network provider
            bool isMatch = true;
            foreach (var pt in config.Networks.Pattern)
            {
                isMatch = Regex.IsMatch(number, pt);
                if (isMatch)
                    break;
            }

            if (!isMatch)
            {
                return true;
            }

            //The last 2 num chars is taboo
            foreach (var i in config.EndwithInvalid)
            {
                if (number.EndsWith(i))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsGoodFengShuiNumbers(string number, FengShuiNumberConfiguration config)
        {
            bool isFengShui = false;

            int totalFirst = 0;
            int totalLast = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (i <= 4)
                    totalFirst += int.Parse(number[i].ToString());
                else
                    totalLast += int.Parse(number[i].ToString());
            }

            foreach (var c in config.TotalMatch)
            {
                if (c.N / c.D == (double)totalFirst / totalLast)
                {
                    isFengShui = true;
                    break;
                }
            }

            if (isFengShui)
            {
                isFengShui = false;
                foreach (var i in config.EndWithValid)
                {
                    if (number.EndsWith(i))
                    {
                        isFengShui = true;
                        break;
                    }
                }
            }

            return isFengShui;
        }
    }
}
