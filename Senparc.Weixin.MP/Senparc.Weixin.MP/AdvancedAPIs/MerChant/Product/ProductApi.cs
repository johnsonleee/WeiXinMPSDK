﻿/*----------------------------------------------------------------
    Copyright (C) 2015 Senparc
    
    文件名：ProductApi.cs
    文件功能描述：微小店商品接口
    
    
    创建标识：Senparc - 20150827
----------------------------------------------------------------*/

/* 
   微小店接口，官方API：http://mp.weixin.qq.com/wiki/index.php?title=%E5%BE%AE%E4%BF%A1%E5%B0%8F%E5%BA%97%E6%8E%A5%E5%8F%A3
*/

using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.CommonAPIs;

namespace Senparc.Weixin.MP.AdvancedAPIs.MerChant
{
    /// <summary>
    /// 微小店接口
    /// </summary>
    public static class ProductApi
    {
        /// <summary>
        /// 增加商品
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="addProductData">提交到接口的数据（AddProductData）</param>
        /// <returns></returns>
        public static AddProductResult AddProduct(string accessToken, AddProductData addProductData)
        {
            var urlFormat = "https://api.weixin.qq.com/merchant/create?access_token={0}";

            return CommonJsonSend.Send<AddProductResult>(accessToken, urlFormat, addProductData);
        }

        /// <summary>
        /// 删除商品              
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId">商品的Id</param>
        /// <returns></returns>
        public static WxJsonResult DeleteProduct(string accessToken, string productId)
        {
            var urlFormat = "https://api.weixin.qq.com/merchant/del?access_token={0}";

            var data = new
            {
                product_id = productId
            };

            return CommonJsonSend.Send<WxJsonResult>(accessToken, urlFormat, data);
        }

        /// <summary>
        /// 修改商品
        /// product_id表示要更新的商品的ID，其他字段说明请参考增加商品接口。
        /// 从未上架的商品所有信息均可修改，否则商品的名称(name)、商品分类(category)、商品属性(property)这三个字段不可修改。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="reviseProduct">修改商品的信息</param>
        /// <returns></returns>
        public static WxJsonResult UpDateProduct(string accessToken, UpdateProductData reviseProduct)
        {
            var urlFormat = "https://api.weixin.qq.com/merchant/update?access_token={0}";

            return CommonJsonSend.Send<WxJsonResult>(accessToken, urlFormat, reviseProduct);
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId">商品的Id</param>
        /// <returns></returns>
        public static GetProductResult GetProduct(string accessToken, string productId)
        {
            var urlFormat = "https://api.weixin.qq.com/merchant/get?access_token={0}";

            var data = new
            {
                product_id = productId
            };

            return CommonJsonSend.Send<GetProductResult>(accessToken, urlFormat, data);
        }

        /// <summary>
        /// 获取指定状态的所有商品
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="status">商品状态(0-全部, 1-上架, 2-下架)</param>
        /// <returns></returns>
        public static GetByStatusResult GetByStatus(string accessToken, int status)
        {
            var urlFormat = "https://api.weixin.qq.com/merchant/getbystatus?access_token={0}";

            var data = new
            {
                status = status
            };

            return CommonJsonSend.Send<GetByStatusResult>(accessToken, urlFormat, data);
        }

        /// <summary>
        /// 商品上下架
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="status">商品上下架标识(0-下架, 1-上架)</param>
        /// <param name="productId">商品ID</param>
        /// <returns></returns>
        public static WxJsonResult ModProductStatus(string accessToken, int status,string productId)
        {
            var urlFormat = "https://api.weixin.qq.com/merchant/modproductstatus?access_token={0}";

            var data = new
            {
                product_id = productId,
                status = status
            };

            return CommonJsonSend.Send<WxJsonResult>(accessToken, urlFormat, data);
        }

        /// <summary>
        /// 获取指定分类的所有子分类
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cateId">大分类ID(根节点分类id为1)</param>
        /// <returns></returns>
        public static GetSubResult GetSub(string accessToken, long cateId)
        {
            var urlFormat = "https://api.weixin.qq.com/merchant/category/getsub?access_token={0}";

            var date = new
            {
                cate_id = cateId
            };

            return CommonJsonSend.Send<GetSubResult>(accessToken, urlFormat, date);
        }

        /// <summary>
        /// 获取指定子分类的所有SKU
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cateId">商品子分类ID</param>
        /// <returns></returns>
        public static GetSkuResult GetSku(string accessToken, long cateId)
        {
            var urlFormat = "https://api.weixin.qq.com/merchant/category/getsku?access_token={0}";

            var data = new
            {
                cate_id = cateId
            };

            return CommonJsonSend.Send<GetSkuResult>(accessToken, urlFormat, data);
        }

        /// <summary>
        /// 获取指定分类的所有属性
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cateId">分类ID</param>
        /// <returns></returns>
        public static GetPropertyResult GetProperty(string accessToken, long cateId)
        {
            var urlFormat = "https://api.weixin.qq.com/merchant/category/getproperty?access_token={0}";

            var data = new
            {
                cate_id = cateId
            };

            return CommonJsonSend.Send<GetPropertyResult>(accessToken, urlFormat, data);
        }
    }
}
