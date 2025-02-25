﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Dynamic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DynamicJsonTests
    {
        [Test]
        public void CanGetIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
            """);

            int value = jsonData.Foo;

            Assert.AreEqual(1, value);
        }

        [Test]
        public void CanGetNestedIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : {
                    "bar" : 1
                  }
                }
                """);

            int value = jsonData.Foo.Bar;

            Assert.AreEqual(1, value);
        }

        [Test]
        public void CanSetIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
                """);

            jsonData.Foo = 2;

            Assert.AreEqual(2, (int)jsonData.Foo);
        }

        [Test]
        public void CanSetNestedIntProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : {
                    "bar" : 1
                  }
                }
                """);

            jsonData.Foo.Bar = 2;

            Assert.AreEqual(2, (int)jsonData.Foo.Bar);
        }

        [Test]
        public void CanGetArrayValue()
        {
            dynamic jsonData = GetDynamicJson("""[0, 1, 2]""");

            Assert.AreEqual(0, (int)jsonData[0]);
            Assert.AreEqual(1, (int)jsonData[1]);
            Assert.AreEqual(2, (int)jsonData[2]);
        }

        [Test]
        public void CanGetNestedArrayValue()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo": [0, 1, 2]
                }
                """);

            Assert.AreEqual(0, (int)jsonData.Foo[0]);
            Assert.AreEqual(1, (int)jsonData.Foo[1]);
            Assert.AreEqual(2, (int)jsonData.Foo[2]);
        }

        [Test]
        public void CanGetPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
                """);

            Assert.AreEqual(1, (int)jsonData["foo"]);
        }

        [Test]
        public void CanGetNestedPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : {
                    "bar" : 1
                  }
                }
                """);

            Assert.AreEqual(1, (int)jsonData.Foo["bar"]);
        }

        [Test]
        public void CanSetArrayValues()
        {
            dynamic jsonData = GetDynamicJson("""[0, 1, 2]""");

            jsonData[0] = 4;
            jsonData[1] = 5;
            jsonData[2] = 6;

            Assert.AreEqual(4, (int)jsonData[0]);
            Assert.AreEqual(5, (int)jsonData[1]);
            Assert.AreEqual(6, (int)jsonData[2]);
        }

        [Test]
        public void CanSetNestedArrayValues()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo": [0, 1, 2]
                }
                """);

            jsonData.Foo[0] = 4;
            jsonData.Foo[1] = 5;
            jsonData.Foo[2] = 6;

            Assert.AreEqual(4, (int)jsonData.Foo[0]);
            Assert.AreEqual(5, (int)jsonData.Foo[1]);
            Assert.AreEqual(6, (int)jsonData.Foo[2]);
        }

        [Test]
        public void CanSetArrayValuesToDifferentTypes()
        {
            dynamic jsonData = GetDynamicJson("""[0, 1, 2, 3]""");

            jsonData[1] = 4;
            jsonData[2] = true;
            jsonData[3] = "string";

            Assert.AreEqual(0, (int)jsonData[0]);
            Assert.AreEqual(4, (int)jsonData[1]);
            Assert.AreEqual(true, (bool)jsonData[2]);
            Assert.AreEqual("string", (string)jsonData[3]);
        }

        [Test]
        public void CanSetNestedArrayValuesToDifferentTypes()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo": [0, 1, 2, 3]
                }
                """);

            jsonData.Foo[1] = 4;
            jsonData.Foo[2] = true;
            jsonData.Foo[3] = "string";

            Assert.AreEqual(0, (int)jsonData.Foo[0]);
            Assert.AreEqual(4, (int)jsonData.Foo[1]);
            Assert.AreEqual(true, (bool)jsonData.Foo[2]);
            Assert.AreEqual("string", (string)jsonData.Foo[3]);
        }

        [Test]
        public void CanGetNullPropertyValue()
        {
            dynamic jsonData = GetDynamicJson("""{ "foo" : null }""");

            Assert.IsNull((CustomType)jsonData.Foo);
            Assert.IsNull((int?)jsonData.Foo);
        }

        [Test]
        public void CanGetNullArrayValue()
        {
            dynamic jsonData = GetDynamicJson("""[ null ]""");

            Assert.IsNull((CustomType)jsonData[0]);
            Assert.IsNull((int?)jsonData[0]);
        }

        [Test]
        public void CanSetPropertyValueToNull()
        {
            dynamic jsonData = GetDynamicJson("""{ "foo" : null }""");

            jsonData.Foo = null;

            Assert.IsNull((CustomType)jsonData.Foo);
            Assert.IsNull((int?)jsonData.Foo);
        }

        [Test]
        public void CanSetArrayValueToNull()
        {
            dynamic jsonData = GetDynamicJson("""[0]""");

            jsonData[0] = null;

            Assert.IsNull((CustomType)jsonData[0]);
            Assert.IsNull((int?)jsonData[0]);
        }

        [Test]
        public void CanSetPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
                """);

            jsonData["Foo"] = 4;

            Assert.AreEqual(4, (int)jsonData["Foo"]);
        }

        [Test]
        public void CanSetNestedPropertyViaIndexer()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : {
                    "bar" : 1
                  }
                }
                """);

            jsonData["foo"]["bar"] = 4;

            Assert.AreEqual(4, (int)jsonData.Foo["bar"]);
        }

        [Test]
        public void CanAddNewProperty()
        {
            dynamic jsonData = GetDynamicJson("""
                {
                  "foo" : 1
                }
                """);

            jsonData.Bar = 2;

            Assert.AreEqual(1, (int)jsonData.Foo);
            Assert.AreEqual(2, (int)jsonData.Bar);
        }

        [Test]
        public void CanMakeChangesAndAddNewProperty()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            dynamic jsonData = BinaryData.FromString("""
                {
                  "foo" : 1
                }
                """).ToDynamicFromJson(options);

            Assert.AreEqual(1, (int)jsonData.Foo);

            jsonData.Foo = "hi";

            Assert.AreEqual("hi", (string)jsonData.Foo);

            jsonData.Bar = 2;

            Assert.AreEqual("hi", (string)jsonData.Foo);
            Assert.AreEqual(2, (int)jsonData.Bar);
        }

        [Test]
        public void CanAddPocoProperty()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            dynamic value = BinaryData.FromBytes("""
                {
                    "foo": 1
                }
                """u8.ToArray()).ToDynamicFromJson(options);

            JsonDataTests.SampleModel model = new()
            {
                Message = "hi",
                Number = 2,
            };

            value.Model = model;

            Assert.IsTrue(value.Foo == 1);
            Assert.IsTrue(value.foo == 1);
            Assert.IsTrue(value.Model.Message == "hi");
            Assert.IsTrue(value.model.message == "hi");
            Assert.IsTrue(value.Model.Number == 2);
            Assert.IsTrue(value.model.number == 2);

            RequestContent content = RequestContent.Create((object)value);
            Stream stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Flush();
            stream.Position = 0;

            BinaryData data = BinaryData.FromStream(stream);
            dynamic roundTripValue = data.ToDynamicFromJson(options);

            Assert.IsTrue(roundTripValue.foo == value.Foo);
            Assert.IsTrue(roundTripValue.model.message == value.Model.Message);
            Assert.IsTrue(roundTripValue.model.number == value.Model.Number);

            Assert.AreEqual(model, (JsonDataTests.SampleModel)roundTripValue.model);
            Assert.AreEqual(model, (JsonDataTests.SampleModel)roundTripValue.Model);
            Assert.AreEqual(model, (JsonDataTests.SampleModel)value.model);
            Assert.AreEqual(model, (JsonDataTests.SampleModel)value.Model);
        }

        [Test]
        public void CanAddNestedPocoProperty()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            dynamic value = BinaryData.FromBytes("""
                {
                    "foo": 1
                }
                """u8.ToArray()).ToDynamicFromJson(options);

            ParentModel model = new ParentModel()
            {
                Name = "Parent",
                Value = new ChildModel()
                {
                    Message = "Child",
                    Number = 1
                }
            };

            value.Model = model;

            Assert.IsTrue(value.Foo == 1);
            Assert.IsTrue(value.foo == 1);
            Assert.IsTrue(value.Model.Name == "Parent");
            Assert.IsTrue(value.model.name == "Parent");
            Assert.IsTrue(value.Model.Value.Message == "Child");
            Assert.IsTrue(value.model.value.message == "Child");

            // Test serialization
            BinaryData jdocBuffer = MutableJsonDocumentTests.GetWriteToBuffer(JsonDocument.Parse(value.ToString()));
            BinaryData dataBuffer = GetWriteToBuffer(value);

            Assert.AreEqual(jdocBuffer.ToString(), dataBuffer.ToString());
            Assert.IsTrue(jdocBuffer.ToMemory().Span.SequenceEqual(dataBuffer.ToMemory().Span),
                "JsonDocument buffer does not match MutableJsonDocument buffer.");

            // Test deserialization
            BinaryData bd = BinaryData.FromString(value.ToString());
            dynamic roundTripValue = bd.ToDynamicFromJson(options);
            Assert.AreEqual(model.Value, (ChildModel)roundTripValue.Model.Value);
            Assert.AreEqual(model, (ParentModel)roundTripValue.Model);
        }

        [Test]
        public void CanSetNestedPocoProperty()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            dynamic value = BinaryData.FromBytes("""
                {
                    "foo": 1
                }
                """u8.ToArray()).ToDynamicFromJson(options);

            ParentModel model = new ParentModel()
            {
                Name = "Parent",
                Value = new ChildModel()
                {
                    Message = "Child",
                    Number = 1
                }
            };

            value.Foo = model;

            Assert.IsTrue(value.Foo.Name == "Parent");
            Assert.IsTrue(value.foo.name == "Parent");
            Assert.IsTrue(value.Foo.Value.Message == "Child");
            Assert.IsTrue(value.foo.value.message == "Child");

            // Test serialization
            BinaryData jdocBuffer = MutableJsonDocumentTests.GetWriteToBuffer(JsonDocument.Parse(value.ToString()));
            BinaryData dataBuffer = GetWriteToBuffer(value);

            Assert.AreEqual(jdocBuffer.ToString(), dataBuffer.ToString());
            Assert.IsTrue(jdocBuffer.ToMemory().Span.SequenceEqual(dataBuffer.ToMemory().Span),
                "JsonDocument buffer does not match MutableJsonDocument buffer.");

            // Test deserialization
            BinaryData bd = BinaryData.FromString(value.ToString());
            dynamic roundTripValue = bd.ToDynamicFromJson(options);
            Assert.AreEqual(model.Value, (ChildModel)roundTripValue.Foo.Value);
            Assert.AreEqual(model, (ParentModel)roundTripValue.Foo);
        }

        internal static BinaryData GetWriteToBuffer(dynamic data)
        {
            using MemoryStream stream = new();
            data.WriteTo(stream);
            stream.Position = 0;
            return BinaryData.FromStream(stream);
        }

        [Test]
        public void CanCheckOptionalProperty()
        {
            dynamic json = GetDynamicJson("""
                {
                  "foo" : "foo"
                }
                """);

            // Property is present
            Assert.IsFalse(json.Foo == null);

            // Property is absent
            Assert.IsTrue(json.Bar == null);
        }

        [Test]
        public void CanCheckOptionalPropertyWithChanges()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            dynamic json = BinaryData.FromString("""
                {
                  "foo" : "foo",
                  "bar" : {
                    "a" : "a"
                  }
                }
            """).ToDynamicFromJson(options);

            // Add property Baz
            json.Baz = "baz";

            // Remove property A
            json.Bar = new { B = "b" };

            // Properties are present
            Assert.IsFalse(json.Foo == null);
            Assert.IsFalse(json.Bar.B == null);
            Assert.IsFalse(json.Baz == null);

            // Properties are absent
            Assert.IsTrue(json.Bar.A == null);
        }

        [Test]
        public void CanSetOptionalProperty()
        {
            dynamic json = GetDynamicJson("""
                {
                  "foo" : "foo"
                }
                """);

            // Property is absent
            Assert.IsTrue(json.OptionalValue == null);

            json.OptionalValue = 5;

            // Property is present
            Assert.IsFalse(json.OptionalValue == null);
            Assert.AreEqual(5, (int)json.OptionalValue);
        }

        [Test]
        public void CanDispose()
        {
            dynamic json = GetDynamicJson("""
                {
                  "foo" : "Hello"
                }
                """);

            json.Dispose();

            Assert.Throws<ObjectDisposedException>(() => { var foo = json.Foo; });
        }

        [Test]
        public void CanDisposeViaUsing()
        {
            string json = """
                {
                  "foo" : "Hello"
                }
                """;

            dynamic outer = default;
            using (dynamic jsonData = GetDynamicJson(json))
            {
                Assert.IsTrue(jsonData.Foo == "Hello");
                outer = jsonData;

                Assert.IsTrue(outer.Foo == "Hello");
            }

            Assert.Throws<ObjectDisposedException>(() => { var foo = outer.Foo; });
        }

        [Test]
        public void DisposingAChildDisposesTheParent()
        {
            dynamic json = GetDynamicJson("""
                {
                  "foo" : {
                    "a": "Hello"
                  }
                }
                """);

            dynamic child = json.Foo.A;
            child.Dispose();

            Assert.Throws<ObjectDisposedException>(() => { var foo = json.Foo; });
        }

        [Test]
        public void ThrowsInvalidCastForOriginalJsonValue()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            dynamic json = BinaryData.FromString(
                """
                {
                    "foo": 1
                }
                """
                ).ToDynamicFromJson(options);

            Exception e = Assert.Throws<InvalidCastException>(() => { var value = (bool)json.Foo; });
            Assert.That(e.Message.Contains(JsonValueKind.Number.ToString()));
        }

        [Test]
        public void ThrowsInvalidCastForChangedJsonValue()
        {
            dynamic json = BinaryData.FromString(
                """
                {
                    "foo": 1
                }
                """
                ).ToDynamicFromJson();

            json.Foo = true;

            Exception e = Assert.Throws<InvalidCastException>(() => { var value = (int)json.Foo; });
            Assert.That(e.Message.Contains(JsonValueKind.True.ToString()));
        }

        [Test]
        public void CanCastToByte()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            dynamic json = BinaryData.FromString("""
                {
                  "foo" : 42
                }
                """).ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.AreEqual((byte)42, (byte)json.Foo);
            Assert.IsTrue(((byte)42) == json.Foo);

            // Get from assigned existing value
            json.Foo = (byte)43;
            Assert.AreEqual((byte)43, (byte)json.Foo);
            Assert.IsTrue(((byte)43) == json.Foo);

            // Get from added value
            json.Bar = (byte)44;
            Assert.AreEqual((byte)44, (byte)json.Bar);
            Assert.IsTrue(((byte)44) == json.Bar);

            // Doesn't work if number change is outside byte range
            json.Foo = 256;
            Assert.Throws<InvalidCastException>(() => { byte b = json.Foo; });

            // Doesn't work for non-number change
            json.Foo = "string";
            Assert.Throws<InvalidCastException>(() => { byte b = json.Foo; });
        }

        [TestCaseSource(nameof(NumberValues))]
        public void CanCastToNumber<T, U>(string serializedX, T x, T y, T z, U invalid)
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            dynamic json = BinaryData.FromString($"{{\"foo\" : {serializedX}}}").ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.AreEqual(x, (T)json.Foo);
            Assert.IsTrue(x == json.Foo);
            Assert.IsTrue(json.Foo == x);

            // Get from assigned existing value
            json.Foo = y;
            Assert.AreEqual(y, (T)json.Foo);
            Assert.IsTrue(y == json.Foo);
            Assert.IsTrue(json.Foo == y);

            // Get from added value
            json.Bar = z;
            Assert.AreEqual(z, (T)json.Bar);
            Assert.IsTrue(z == json.Bar);
            Assert.IsTrue(json.Bar == z);

            // Doesn't work if number change is outside T range
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
            if (invalid is bool testRange && testRange)
            {
                json.Foo = invalid;
                Assert.Throws<InvalidCastException>(() => { T b = json.Foo; });
            }

            // Doesn't work for non-number change
            json.Foo = "string";
            Assert.Throws<InvalidCastException>(() => { T b = json.Foo; });
        }

        [Test]
        public void CanExplicitCastToGuid()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            Guid guid = Guid.NewGuid();
            dynamic json = BinaryData.FromString($"{{\"foo\" : \"{guid}\"}}").ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.AreEqual(guid, (Guid)json.Foo);
            Assert.IsTrue(guid == (Guid)json.Foo);
            Assert.IsTrue((Guid)json.Foo == guid);

            // Get from assigned existing value
            Guid fooValue = Guid.NewGuid();
            json.Foo = fooValue;
            Assert.AreEqual(fooValue, (Guid)json.Foo);
            Assert.IsTrue(fooValue == (Guid)json.Foo);
            Assert.IsTrue((Guid)json.Foo == fooValue);

            // Get from added value
            Guid barValue = Guid.NewGuid();
            json.Bar = barValue;
            Assert.AreEqual(barValue, (Guid)json.Bar);
            Assert.IsTrue(barValue == (Guid)json.Bar);
            Assert.IsTrue((Guid)json.Bar == barValue);

            // Also works as a string
            Assert.AreEqual(fooValue.ToString(), (string)json.Foo);
            Assert.IsTrue(fooValue.ToString() == json.Foo);
            Assert.IsTrue(json.Foo == fooValue.ToString());

            Assert.AreEqual(barValue.ToString(), (string)json.Bar);
            Assert.IsTrue(barValue.ToString() == json.Bar);
            Assert.IsTrue(json.Bar == barValue.ToString());

            // Doesn't work for non-string change
            json.Foo = "false";
            Assert.Throws<InvalidCastException>(() => { Guid g = (Guid)json.Foo; });
        }

        [Test]
        public void CanExplicitCastToDateTime()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            DateTime dateTime = DateTime.UtcNow;
            string dateTimeString = FormatDateTime(dateTime);
            dynamic json = BinaryData.FromString($"{{\"foo\" : \"{dateTimeString}\"}}").ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.AreEqual(dateTime, (DateTime)json.Foo);
            Assert.IsTrue(dateTime == (DateTime)json.Foo);
            Assert.IsTrue((DateTime)json.Foo == dateTime);

            // Get from assigned existing value
            DateTime fooValue = DateTime.UtcNow.AddDays(1);
            json.Foo = fooValue;
            Assert.AreEqual(fooValue, (DateTime)json.Foo);
            Assert.IsTrue(fooValue == (DateTime)json.Foo);
            Assert.IsTrue((DateTime)json.Foo == fooValue);

            // Get from added value
            DateTime barValue = DateTime.UtcNow.AddDays(2);
            json.Bar = barValue;
            Assert.AreEqual(barValue, (DateTime)json.Bar);
            Assert.IsTrue(barValue == (DateTime)json.Bar);
            Assert.IsTrue((DateTime)json.Bar == barValue);

            // Also works as a string
            string fooValueString = FormatDateTime(fooValue);
            Assert.AreEqual(fooValueString, (string)json.Foo);
            Assert.IsTrue(fooValueString == json.Foo);
            Assert.IsTrue(json.Foo == fooValueString);

            string barValueString = FormatDateTime(barValue);
            Assert.AreEqual(barValueString, (string)json.Bar);
            Assert.IsTrue(barValueString == json.Bar);
            Assert.IsTrue(json.Bar == barValueString);

            // Doesn't work for non-string change
            json.Foo = "false";
            Assert.Throws<InvalidCastException>(() => { DateTime g = (DateTime)json.Foo; });
        }

        [Test]
        public void CanExplicitCastToDateTimeOffset()
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            DateTimeOffset dateTime = DateTimeOffset.UtcNow;
            string dateTimeString = FormatDateTimeOffset(dateTime);
            dynamic json = BinaryData.FromString($"{{\"foo\" : \"{dateTimeString}\"}}").ToDynamicFromJson(options);

            // Get from parsed JSON
            Assert.AreEqual(dateTime, (DateTimeOffset)json.Foo);
            Assert.IsTrue(dateTime == (DateTimeOffset)json.Foo);
            Assert.IsTrue((DateTimeOffset)json.Foo == dateTime);

            // Get from assigned existing value
            DateTimeOffset fooValue = DateTimeOffset.UtcNow.AddDays(1);
            json.Foo = fooValue;
            Assert.AreEqual(fooValue, (DateTimeOffset)json.Foo);
            Assert.IsTrue(fooValue == (DateTimeOffset)json.Foo);
            Assert.IsTrue((DateTimeOffset)json.Foo == fooValue);

            // Get from added value
            DateTimeOffset barValue = DateTimeOffset.UtcNow.AddDays(2);
            json.Bar = barValue;
            Assert.AreEqual(barValue, (DateTimeOffset)json.Bar);
            Assert.IsTrue(barValue == (DateTimeOffset)json.Bar);
            Assert.IsTrue((DateTimeOffset)json.Bar == barValue);

            // Also works as a string
            string fooValueString = FormatDateTimeOffset(fooValue);
            Assert.AreEqual(fooValueString, (string)json.Foo);
            Assert.IsTrue(fooValueString == json.Foo);
            Assert.IsTrue(json.Foo == fooValueString);

            string barValueString = FormatDateTimeOffset(barValue);
            Assert.AreEqual(barValueString, (string)json.Bar);
            Assert.IsTrue(barValueString == json.Bar);
            Assert.IsTrue(json.Bar == barValueString);

            // Doesn't work for non-string change
            json.Foo = "false";
            Assert.Throws<InvalidCastException>(() => { DateTimeOffset d = (DateTimeOffset)json.Foo; });
        }

        internal static string FormatDateTime(DateTime d)
        {
            return d.ToUniversalTime().ToString("o");
        }

        internal static string FormatDateTimeOffset(DateTimeOffset d)
        {
            return d.ToUniversalTime().UtcDateTime.ToString("o");
        }

        [Test]
        public void CanRoundTripUnixDateTime()
        {
            DynamicDataOptions options = new DynamicDataOptions()
            {
                DateTimeHandling = DynamicDateTimeHandling.UnixTime
            };

            dynamic value = BinaryData.FromString("""{ "foo": 0 }""").ToDynamicFromJson(options);

            // Existing value
            value.Foo = DateTimeOffset.UtcNow;

            // New Value
            value.Bar = DateTimeOffset.UtcNow.AddDays(1);

            void validate(dynamic a, dynamic b)
            {
                Assert.AreEqual((long)a, (long)b);
                Assert.AreEqual((DateTime)a, (DateTime)b);
                Assert.AreEqual((DateTimeOffset)a, (DateTimeOffset)b);
            }

            string json = value.ToString();
            dynamic fromString = BinaryData.FromString(json).ToDynamicFromJson(options);
            validate(value.Foo, fromString.Foo);
            validate(value.Bar, fromString.Bar);

            BinaryData data = GetWriteToBuffer(value);
            dynamic fromWriteTo = data.ToDynamicFromJson(options);
            validate(value.Foo, fromWriteTo.Foo);
            validate(value.Bar, fromWriteTo.Bar);
        }

        [Test]
        public void ThrowsOnNonUtcDateTimeAssignment()
        {
            dynamic value = BinaryData.FromString("""{ "foo": 0 }""").ToDynamicFromJson();

            Assert.Throws<NotSupportedException>(() => value.Foo = DateTime.Now);
        }

        [Test]
        public void CanDifferentiateBetweenNullAndAbsent()
        {
            dynamic json = BinaryData.FromString("""{ "foo": null }""").ToDynamicFromJson();

            // GetMember binding mirrors Azure SDK models, so we allow a null check for an optional
            // property through the C#-style dynamic interface.
            Assert.IsTrue(json.foo == null);
            Assert.IsTrue(json.bar == null);

            // Indexer lookup mimics JsonNode behavior and so throws if a property is absent.
            Assert.IsTrue(json["foo"] == null);
            Assert.Throws<KeyNotFoundException>(() => _ = json["bar"]);
            Assert.Throws<KeyNotFoundException>(() => { if (json["bar"] == null) {; } });
        }

        #region Helpers
        internal static dynamic GetDynamicJson(string json)
        {
            DynamicDataOptions options = new() { CaseMapping = DynamicCaseMapping.PascalToCamel };
            return new BinaryData(json).ToDynamicFromJson(options);
        }

        public static IEnumerable<object[]> NumberValues()
        {
            // Valid ranges:
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
            yield return new object[] { "42", (byte)42, (byte)43, (byte)44, 256 };
            yield return new object[] { "42", (sbyte)42, (sbyte)43, (sbyte)44, 128 };
            yield return new object[] { "42", (short)42, (short)43, (short)44, 32768 };
            yield return new object[] { "42", (ushort)42, (ushort)43, (ushort)44, 65536 };
            yield return new object[] { "42", 42, 43, 44, 2147483648 };
            yield return new object[] { "42", 42u, 43u, 44u, 4294967296 };
            yield return new object[] { "42", 42L, 43L, 44L, 9223372036854775808 };
            yield return new object[] { "42", 42ul, 43ul, 44ul, -1 };
            yield return new object[] { "42.1", 42.1f, 43.1f, 44.1f, false /* don't test range */ };
            yield return new object[] { "42.1", 42.1d, 43.1d, 44.1d, false /* don't test range */ };
            yield return new object[] { "42.1", 42.1m, 43.1m, 44.1m, false /* don't test range */ };
        }

        internal class CustomType
        {
        }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        internal class ParentModel : IEquatable<ParentModel>
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            public string Name { get; set; }
            public ChildModel Value { get; set; }

            public override bool Equals(object obj)
            {
                ParentModel other = obj as ParentModel;
                if (other == null)
                {
                    return false;
                }

                return Equals(other);
            }

            public bool Equals(ParentModel obj)
            {
                return Name == obj.Name && Value.Equals(obj.Value);
            }
        }

        internal class ChildModel : IEquatable<ChildModel>
        {
            public string Message { get; set; }
            public int Number { get; set; }

            public override bool Equals(object obj)
            {
                ChildModel other = obj as ChildModel;
                if (other == null)
                {
                    return false;
                }

                return Equals(other);
            }

            public bool Equals(ChildModel obj)
            {
                return Message == obj.Message && Number == obj.Number;
            }
        }
        #endregion
    }
}
