import { Button, Col, Row, Table } from "antd";
import { removeFromCart } from "../redux/cartSlice";
import { useDispatch, useSelector } from "react-redux";
import Text from "antd/lib/typography/Text";
const columns = [
  {
    title: "Name",
    dataIndex: "name",
    key: "name",
  },
  {
    title: "Price",
    align: "right",
    key: "price",
    render: (record) => (
      <Text>{(record.basePrice + record.taxValue).toFixed(2)}</Text>
    ),
  },
  {
    title: "Action",
    render: (record) => <RemoveFromCartButton record={record} />,
    key: "action",
  },
];

const RemoveFromCartButton = ({ record }) => {
  const dispatch = useDispatch();
  return (
    <>
      <Button
        onClick={() => {
          dispatch(
            removeFromCart({
              item: record,
            })
          );
        }}
      >
        Remove
      </Button>
    </>
  );
};

const ItemCart = () => {
  const state = useSelector((state) => state.cart);
  const Footer = () => (
    <>
      <Row>
        <Col>
          <Text>Sales Taxes: </Text>
        </Col>
        <Col>{state.taxSum.toFixed(2)}</Col>
      </Row>
      <Row>
        <Col>Total: </Col>
        <Col>{(state.taxSum + state.baseSum).toFixed(2)}</Col>
      </Row>
    </>
  );
  return (
    <>
      <Table
        columns={columns}
        dataSource={state.items}
        bordered
        pagination={false}
        rowKey="taxableItemId"
        footer={() => <Footer />}
      />
      ;
    </>
  );
};

export default ItemCart;
