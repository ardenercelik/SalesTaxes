import React from "react";

import "./App.css";
import { ItemTable, ItemCart } from "./component";
import { Col, Row } from "antd";
import store from "./redux/store";
import { Provider } from "react-redux";
import Title from "antd/lib/typography/Title";

export default function App() {
  return (
    <Provider store={store}>
      <Row>
        <div
          style={{
            display: "flex",
            justifyContent: "space-around",
            marginLeft: "auto",
            marginRight: "auto",
          }}
        >
          <Col span={12}>
            <Title>Items</Title>
            <ItemTable />
          </Col>
          <Col span={8}>
            <Title>Cart</Title>
            <ItemCart />
          </Col>
        </div>
      </Row>
    </Provider>
  );
}
