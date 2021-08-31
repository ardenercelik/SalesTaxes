import { createSlice } from "@reduxjs/toolkit";

export const cartSlice = createSlice({
  name: "cart",
  initialState: { items: [], baseSum: 0, taxSum: 0 },
  reducers: {
    addToCart: (state, action) => {
      let oldItems = [...state.items];
      const index = state.items.findIndex(
        (item) => item.taxableItemId === action.payload.item.taxableItemId
      );
      if (index === -1) {
        oldItems.push(action.payload.item);
        const newState = {
          items: oldItems,
          baseSum: state.baseSum + action.payload.item.basePrice,
          taxSum: state.taxSum + action.payload.item.taxValue,
        };
        return newState;
      } else {
        alert("Item already exists in the cart");
      }
    },
    removeFromCart: (state, action) => {
      const newState = {
        items: state.items.filter(
          (item) => item.taxableItemId !== action.payload.item.taxableItemId
        ),
        baseSum: state.baseSum - action.payload.item.basePrice,
        taxSum: state.taxSum - action.payload.item.taxValue,
      };
      return newState;
    },
  },
});

export const { addToCart, removeFromCart } = cartSlice.actions;

export default cartSlice.reducer;
