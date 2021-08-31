import { Button, Table } from "antd";
import { useQuery } from "react-query";
import TaxesAPI from "../api/taxesApi";
import { addToCart } from "../redux/cartSlice";
import { useDispatch } from "react-redux";
import FormLayoutDemo from "./AddItemFrom";
const columns = [
  {
    title: "Name",
    dataIndex: "name",
    key: "name",
  },
  {
    title: "Price",
    key: "price",
    dataIndex: "basePrice",
    align: "right",
  },
  {
    title: "Action",
    render: (record) => <AddToCartButton record={record} />,
    key: "action",
  },
];

const AddToCartButton = ({ record }) => {
  const dispatch = useDispatch();
  return (
    <>
      <Button
        onClick={() => {
          dispatch(
            addToCart({
              item: record,
            })
          );
        }}
      >
        Add to Cart
      </Button>
    </>
  );
};

const ItemTable = () => {
  const { isLoading, data } = useQuery("items", () =>
    TaxesAPI.getItems().then((resp) => resp.data)
  );

  return (
    <>
      <Table
        columns={columns}
        loading={isLoading}
        dataSource={data}
        bordered
        pagination={false}
        rowKey="taxableItemId"
        title={() => <FormLayoutDemo />}
      />
      ;
    </>
  );
};

export default ItemTable;
