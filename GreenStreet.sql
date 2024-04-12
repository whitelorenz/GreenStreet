-- this will not include businesses with zero footprint
select b.business, p.street_no, p.street, p.postcode, sum(f.count) as "Total footfall"
from businesses b
inner join 
	premises p on b.id=p.business_id
inner join 
	footfall f on p.id=f.premises_id
group by premises_id;

-- This will include businesses with 0 footprint
select b.business, ifnull(p.street_no, ''), p.street, p.postcode, ifnull(footprint, 0)
from businesses b
inner join 
	premises p on b.id=p.business_id
left join 
(select premises_id, sum(count) as footprint
from footfall
group by premises_id) f on p.id=f.premises_id;