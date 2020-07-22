using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCompany.Models.DaData.Adresses
{
    public class Address
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_iso_code")]
        public string CountryISOCode { get; set; }

        [JsonProperty("federal_district")]
        public string FederalDistrict { get; set; }

        [JsonProperty("region_fias_id")]
        public string RegionFiasId { get; set; }

        [JsonProperty("region_kladr_id")]
        public string RegionKladrId { get; set; }

        [JsonProperty("region_iso_code")]
        public string RegionISOCode { get; set; }

        [JsonProperty("region_with_type")]
        public string RegionWithType { get; set; }

        [JsonProperty("region_type")]
        public string RegionType { get; set; }

        [JsonProperty("region_type_full")]
        public string RegionTypeFull { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("area_fias_id")]
        public string AreaFiasId { get; set; }

        [JsonProperty("area_kladr_id")]
        public string AreaKladrId { get; set; }

        [JsonProperty("area_with_type")]
        public string AreaWithType { get; set; }

        [JsonProperty("area_type")]
        public string AreaType { get; set; }

        [JsonProperty("area_type_full")]
        public string AreaTypeFull { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("city_fias_id")]
        public string CityFiasId { get; set; }

        [JsonProperty("city_kladr_id")]
        public string CityKladrId { get; set; }

        [JsonProperty("city_with_type")]
        public string CityWithType { get; set; }

        [JsonProperty("city_type")]
        public string CityType { get; set; }

        [JsonProperty("city_type_full")]
        public string CityTypeFull { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("city_area")]
        public string CityArea { get; set; }


        [JsonProperty("city_district_fias_id")]
        public string CityDistrictFiasId { get; set; }

        [JsonProperty("city_district_kladr_id")]
        public string CityDistrictKladrId { get; set; }

        [JsonProperty("city_district_with_type")]
        public string CityDistrictWithType { get; set; }

        [JsonProperty("city_district_type")]
        public string CityDistrictType { get; set; }

        [JsonProperty("city_district_type_full")]
        public string CityDistrictTypeFull { get; set; }

        [JsonProperty("city_district")]
        public string DityDistrict { get; set; }

        [JsonProperty("settlement_fias_id")]
        public string SettlementFiasDd { get; set; }

        [JsonProperty("settlement_kladr_id")]
        public string SettlementKladrId { get; set; }

        [JsonProperty("settlement_with_type")]
        public string SettlementWithType { get; set; }

        [JsonProperty("settlement_type")]
        public string SettlementType { get; set; }

        [JsonProperty("settlement_type_full")]
        public string SettlementTypeFull { get; set; }

        [JsonProperty("settlement")]
        public string Settlement { get; set; }


        [JsonProperty("street_fias_id")]
        public string StreetFiasId { get; set; }

        [JsonProperty("street_kladr_id")]
        public string StreetKladrId { get; set; }

        [JsonProperty("street_with_type")]
        public string StreetWithType { get; set; }

        [JsonProperty("street_type")]
        public string StreetType { get; set; }

        [JsonProperty("street_type_full")]
        public string StreetTypeFull { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("house_fias_id")]
        public string HouseFiasId { get; set; }

        [JsonProperty("house_kladr_id")]
        public string HouseKladrId { get; set; }

        [JsonProperty("house_with_type")]
        public string HouseWithType { get; set; }

        [JsonProperty("house_type")]
        public string HouseType { get; set; }

        [JsonProperty("house_type_full")]
        public string HouseTypeFull { get; set; }

        [JsonProperty("house")]
        public string House { get; set; }


        [JsonProperty("block_type")]
        public string BlockType { get; set; }

        [JsonProperty("block_type_full")]
        public string BlockTypeFull { get; set; }

        [JsonProperty("block")]
        public string Block { get; set; }


        [JsonProperty("flat_type")]
        public string FlatType { get; set; }

        [JsonProperty("flat_type_full")]
        public string FlatTypeFull { get; set; }

        [JsonProperty("flat")]
        public string Flat { get; set; }

        [JsonProperty("flat_area")]
        public string FlatArea { get; set; }

        [JsonProperty("square_meter_price")]
        public string SquareMeterPrice { get; set; }

        [JsonProperty("flat_price")]
        public string FlatPrice { get; set; }

        [JsonProperty("postal_box")]
        public string PostalBox { get; set; }

        [JsonProperty("fias_id")]
        public string FiasId { get; set; }

        [JsonProperty("fias_code")]
        public string FiasCode { get; set; }

        [JsonProperty("fias_level")]
        public string FiasLevel { get; set; }

        [JsonProperty("fias_actuality_state")]
        public string FiasActualityState { get; set; }

        [JsonProperty("kladr_id")]
        public string KladrId { get; set; }

        [JsonProperty("capital_marker")]
        public string CapitalMarker { get; set; }


        [JsonProperty("okato")]
        public string Okato { get; set; }

        [JsonProperty("oktmo")]
        public string Oktmo { get; set; }

        [JsonProperty("tax_office")]
        public string TaxOffice { get; set; }

        [JsonProperty("tax_office_legal")]
        public string TaxOfficeLegal { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }


        [JsonProperty("geo_lat")]
        public string GeoLat { get; set; }

        [JsonProperty("geo_lon")]
        public string GeoLon { get; set; }

        [JsonProperty("beltway_hit")]
        public string BeltwayHit { get; set; }

        [JsonProperty("beltway_distance")]
        public string BeltwayDistance { get; set; }

        [JsonProperty("qc_geo")]
        public string QCGeo { get; set; }

        [JsonProperty("qc_complete")]
        public string qc_complete { get; set; }

        [JsonProperty("qc_house")]
        public string QCHouse { get; set; }

        [JsonProperty("qc")]
        public string QC { get; set; }

        [JsonProperty("unparsed_parts")]
        public string UnparsedParts { get; set; }

        [JsonProperty("history_values")]
        public List<string> HistoryValues { get; set; }

        [JsonProperty("metro")]
        public List<Metro> Metro { get; set; }

        [JsonProperty("structure_type")]
        public string StructureType { get; set; }

        public override string ToString()
        {
            return string.Format(
                "[AddressData: source={0}, postal_code={1}, result={2}, qc={3}]",
                Source, PostalCode, Result, QC
            );
        }
    }
}
