using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CH.Spartan.DeviceTypes;
using CH.Spartan.EntityFramework;
using CH.Spartan.Infrastructure;
using CH.Spartan.Nodes;

namespace CH.Spartan.Migrations.SeedData
{
   public class DefaultDataBuilder
    {

        private readonly SpartanDbContext _context;

        public DefaultDataBuilder(SpartanDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //添加设备类型
            CreateDeviceType();
            //添加节点
            CreateNode();
        }

       private void CreateNode()
       {
           for (var i = 1; i <= 5; i++)
           {
               var nodeName = "T" + i;
               var node = _context.Nodes.FirstOrDefault(p => p.Name == nodeName);
               if (node == null)
               {
                   node = new Node
                   {
                       Name = nodeName,
                       HistoryTableName = "historys" + i
                   };
                   _context.Nodes.Add(node);
               }
           }

       }

       private void CreateDeviceType()
       {
           var d10 = _context.DeviceTypes.FirstOrDefault(p => p.Name == DeviceType.D10);
           if (d10 == null)
           {
               d10 = new DeviceType
               {
                   Name = DeviceType.D10,
                   CodeCreateRule = EnumCodeCreateRule.No,
                   SwitchInGateway = "120.24.100.60:8102",
                   ServiceCharge = 50,
                   Supplier = "",
                   Manufacturer = ""
               };
               _context.DeviceTypes.Add(d10);
           }

           var gt02 = _context.DeviceTypes.FirstOrDefault(p => p.Name == DeviceType.Gt02);
           if (gt02 == null)
           {
               gt02 = new DeviceType
               {
                   Name = DeviceType.Gt02,
                   CodeCreateRule = EnumCodeCreateRule.No,
                   SwitchInGateway = "120.24.100.60:8104",
                   ServiceCharge = 50,
                   Supplier = "",
                   Manufacturer = ""
               };
               _context.DeviceTypes.Add(gt02);
           }

           var gt06 = _context.DeviceTypes.FirstOrDefault(p => p.Name == DeviceType.Gt06);
           if (gt06 == null)
           {
               gt06 = new DeviceType
               {
                   Name = DeviceType.Gt06,
                   CodeCreateRule = EnumCodeCreateRule.No,
                   SwitchInGateway = "120.24.100.60:8103",
                   ServiceCharge = 50,
                   Supplier = "",
                   Manufacturer = ""
               };
               _context.DeviceTypes.Add(gt06);
           }


           var gt07 = _context.DeviceTypes.FirstOrDefault(p => p.Name == DeviceType.Gt07);
           if (gt07 == null)
           {
               gt07 = new DeviceType
               {
                   Name = DeviceType.Gt07,
                   CodeCreateRule = EnumCodeCreateRule.No,
                   SwitchInGateway = "120.24.100.60:8105",
                   ServiceCharge = 50,
                   Supplier = "",
                   Manufacturer = ""
               };
               _context.DeviceTypes.Add(gt07);
           }

           var h1 = _context.DeviceTypes.FirstOrDefault(p => p.Name == DeviceType.H1);
           if (h1 == null)
           {
               h1 = new DeviceType
               {
                   Name = DeviceType.H1,
                   CodeCreateRule = EnumCodeCreateRule.No,
                   SwitchInGateway = "120.24.100.60:8101",
                   ServiceCharge = 50,
                   Supplier = "",
                   Manufacturer = ""
               };
               _context.DeviceTypes.Add(h1);
           }

           var h5 = _context.DeviceTypes.FirstOrDefault(p => p.Name == DeviceType.H5);
           if (h5 == null)
           {
               h5 = new DeviceType
               {
                   Name = DeviceType.H5,
                   CodeCreateRule = EnumCodeCreateRule.No,
                   SwitchInGateway = "120.24.100.60:8101",
                   ServiceCharge = 50,
                   Supplier = "",
                   Manufacturer = ""
               };
               _context.DeviceTypes.Add(h5);
           }

           var t1 = _context.DeviceTypes.FirstOrDefault(p => p.Name == DeviceType.T1);
           if (t1 == null)
           {
               t1 = new DeviceType
               {
                   Name = DeviceType.T1,
                   CodeCreateRule = EnumCodeCreateRule.No,
                   SwitchInGateway = "120.24.100.60:8106",
                   ServiceCharge = 50,
                   Supplier = "",
                   Manufacturer = ""
               };
               _context.DeviceTypes.Add(t1);
           }

           var t2 = _context.DeviceTypes.FirstOrDefault(p => p.Name == DeviceType.T2);
           if (t2 == null)
           {
               t2 = new DeviceType
               {
                   Name = DeviceType.T2,
                   CodeCreateRule = EnumCodeCreateRule.No,
                   SwitchInGateway = "120.24.100.60:8106",
                   ServiceCharge = 50,
                   Supplier = "",
                   Manufacturer = ""
               };
               _context.DeviceTypes.Add(t2);
           }
       }
    }
}
