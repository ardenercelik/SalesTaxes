import React from "react";
import { Form, Input, Button, Row, Select } from "antd";
import { Option } from "antd/lib/mentions";
import TaxesAPI from "../api/taxesApi";
import { useQuery } from "react-query";
const FormLayoutDemo = () => {
  const [form] = Form.useForm();
  const { data, isSuccess, refetch } = useQuery("items", () =>
    TaxesAPI.getItems().then((resp) => resp.data)
  );
  const onFinish = (values) => {
    console.log(values);
    const data = JSON.stringify(values);
    TaxesAPI.postItem(data).then(function (response) {
      console.log(response);
      refetch();
    });
  };

  return (
    <>
      <Form
        layout={"inline"}
        form={form}
        initialValues={{
          layout: "inline",
        }}
        onFinish={onFinish}
        style={{ height: 100 }}
      >
        <Row>
          <Form.Item
            label="Name"
            name="name"
            rules={[
              {
                required: true,
                message: "Please input name",
              },
            ]}
          >
            <Input placeholder="Item Name" />
          </Form.Item>
          <Form.Item
            label="Price"
            name="basePrice"
            rules={[
              {
                required: true,
                message: "Please input price",
              },
            ]}
          >
            <Input placeholder="Base Price" />
          </Form.Item>
        </Row>
        <Row>
          <Form.Item
            name="isExempt"
            label="Exempt"
            rules={[
              {
                required: true,
              },
            ]}
          >
            <Select placeholder="Is exempt?" allowClear>
              <Option value={true}>true</Option>
              <Option value={false}>false</Option>
            </Select>
          </Form.Item>
          <Form.Item
            name="isImported"
            label="Imported"
            rules={[
              {
                required: true,
              },
            ]}
          >
            <Select placeholder="Is imported?" allowClear>
              <Option value={true}>true</Option>
              <Option value={false}>false</Option>
            </Select>
          </Form.Item>
          <Form.Item>
            <Button type="primary" htmlType="submit">
              Submit
            </Button>
          </Form.Item>
        </Row>
      </Form>
    </>
  );
};
export default FormLayoutDemo;
