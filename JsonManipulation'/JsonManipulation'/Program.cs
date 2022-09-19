﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonManipulation_
{
    class Program
    {
        static void Main(string[] args)
        {
            var source= "[{\"id\":\"7f91442e-93d5 - 4077 - a2df - 701b63f5cf46\",\"text\":\"Company Code\",\"entityName\":\"ICMLeadingCostCenterMaster\",\"field\":\"ICMCompanyCode\",\"dataType\":\"String\",\"tile\":true,\"ref\":0,\"isLocalized\":false,\"search\":true,\"isLookup\":false,\"isVisibleOnDetails\":true,\"detailsDisplayOrder\":4,\"displayOrder\":2,\"guid\":\"8874ab36 - 420e-4a7b - aef9 - 2f39a12b5872\",\"index\":\"iCMCompanyCode\",\"display\":true},{\"id\":\"8a54d563 - 5037 - 433f - b6d1 - 5310d501bc90\",\"text\":\"Controller Group\",\"entityName\":\"ICMLeadingCostCenterMaster\",\"field\":\"ICMControllerGroup\",\"dataType\":\"String\",\"tile\":false,\"ref\":0,\"isLocalized\":false,\"search\":true,\"isLookup\":false,\"isVisibleOnDetails\":true,\"detailsDisplayOrder\":9,\"displayOrder\":7,\"guid\":\"d5691658 - 5ca0 - 48e4 - 85ee - cbdd2372a7aa\",\"index\":\"iCMControllerGroup\",\"display\":true},{\"id\":\"d318da11 - 87b8 - 41e4 - a8dc - 4c99d1f4f144\",\"text\":\"Cost Center\",\"entityName\":\"ICMLeadingCostCenterMaster\",\"field\":\"ICMCostCenter\",\"dataType\":\"String\",\"tile\":true,\"ref\":0,\"isLocalized\":false,\"search\":true,\"isLookup\":false,\"isVisibleOnDetails\":true,\"detailsDisplayOrder\":5,\"displayOrder\":8,\"guid\":\"24df91ac - 1fe5 - 4af9 - af84 - f88a40130378\",\"index\":\"iCMCostCenter\",\"display\":true},{\"id\":\"d2ad4785 - 0f50 - 452e-8b50 - ae524c060a8c\",\"text\":\"Cost Center Name\",\"entityName\":\"ICMLeadingCostCenterMaster\",\"field\":\"ICMCostCenterName\",\"dataType\":\"String\",\"tile\":true,\"ref\":0,\"isLocalized\":false,\"search\":true,\"isLookup\":false,\"isVisibleOnDetails\":true,\"detailsDisplayOrder\":6,\"displayOrder\":9,\"guid\":\"1cf8e843 - 8a17 - 46c6 - 98ee - 64461ba17d2a\",\"index\":\"iCMCostCenterName\",\"display\":true},{\"id\":\"84d0dbe6 - a530 - 42ae - 9be6 - 866afd5fc1b4\",\"text\":\"Department\",\"entityName\":\"ICMLeadingCostCenterMaster\",\"field\":\"ICMDepartment\",\"dataType\":\"String\",\"tile\":false,\"ref\":0,\"isLocalized\":false,\"search\":true,\"isLookup\":false,\"isVisibleOnDetails\":true,\"detailsDisplayOrder\":8,\"displayOrder\":12,\"guid\":\"98b1b9a6 - 974c - 48d9 - a9a6 - 600688f9e8de\",\"index\":\"iCMDepartment\",\"display\":true},{\"id\":\"8c88eee9 - 4e7b - 49eb - b182 - 182d00b8b6c0\",\"text\":\"Leading Cost Center\",\"entityName\":\"ICMLeadingCostCenterMaster\",\"field\":\"ICMLeadingCostCenter\",\"dataType\":\"String\",\"tile\":true,\"ref\":0,\"isLocalized\":false,\"search\":true,\"isLookup\":false,\"isVisibleOnDetails\":true,\"detailsDisplayOrder\":3,\"displayOrder\":15,\"guid\":\"9d100dbc - fbea - 4c1e - a481 - 8e44a2f0e808\",\"index\":\"iCMLeadingCostCenter\",\"display\":true},{\"id\":\"ae608686 - bb15 - 43a7 - bc80 - 0d23daebd9c8\",\"text\":\"Management Center\",\"entityName\":\"ICMLeadingCostCenterMaster\",\"field\":\"ICMManagementCenter\",\"dataType\":\"String\",\"tile\":false,\"ref\":0,\"isLocalized\":false,\"search\":true,\"isLookup\":false,\"isVisibleOnDetails\":true,\"detailsDisplayOrder\":7,\"displayOrder\":19,\"guid\":\"6a9bf605 - ac52 - 4347 - b237 - 9c66311bb735\",\"index\":\"iCMManagementCenter\",\"display\":true}]";

            var target= "{\"fields\":[{\"text\":\"ICMLeadingCostCenter\",\"targetField\":false},{\"text\":\"ICMCompanyCode\",\"targetField\":false},{\"text\":\"ICMCostCenter\",\"targetField\":false},{\"text\":\"ICMCostCenterName\",\"targetField\":false},{\"text\":\"ICMManagementCenter\",\"targetField\":false},{\"text\":\"ICMDepartment\",\"targetField\":false},{\"text\":\"ICMControllerGroup\",\"targetField\":false}]}";
        }

    }
}